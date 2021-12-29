using UnityEngine;

using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace ClientCore
{
	public class Poolable : MonoBehaviour
	{
		public bool IsInUse => gameObject.activeSelf;

		[SerializeField] protected UnityEvent _OnActivate;
		[SerializeField] protected UnityEvent _OnDeActivate;

        public void Activate()
        {
            gameObject.SetActive(true);
            _OnActivate.Invoke();
        }
        public void Deactivate()
        {
            gameObject.SetActive(false);
            _OnDeActivate.Invoke();
        }
	}

    /// <summary>
    /// 기본 오브젝트 풀
    /// </summary>
	public class ObjectPool
    {
	    private List<Poolable> _pool = new List<Poolable>();

		public void Add(Poolable obj) => _pool.Add(obj);
		public Poolable[] ToArray() => _pool.ToArray();

		public Poolable Spawn()
		{ 
			var obj = _pool.Find(Poolable => !Poolable.IsInUse);
			return obj;
		}

		public void Refresh()
		{ 
			var inUseList = _pool.FindAll(poolable => poolable.IsInUse);
            _pool.Clear();

            var reserveSize = inUseList.Count << 1;
            _pool.Reverse(0, reserveSize);
            _pool.AddRange(inUseList);
		}

	}
}


//.net ConcurrentBag을 이용한 병행 오브젝트풀 예시
namespace ConcurrentPool
{
    public class ObjectPool<T>
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objects = new ConcurrentBag<T>();
        }

        public T Get() => _objects.TryTake(out T item) ? item : _objectGenerator();

        public void Return(T item) => _objects.Add(item);
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var cts = new CancellationTokenSource();

            // Create an opportunity for the user to cancel.
            _ = Task.Run(() =>
            {
                if (char.ToUpperInvariant(Console.ReadKey().KeyChar) == 'C')
                {
                    cts.Cancel();
                }
            });

            var pool = new ObjectPool<ExampleObject>(() => new ExampleObject());

            // Create a high demand for ExampleObject instance.
            Parallel.For(0, 1000000, (i, loopState) =>
            {
                var example = pool.Get();
                try
                {
                    Console.CursorLeft = 0;
                    // This is the bottleneck in our application. All threads in this loop
                    // must serialize their access to the static Console class.
                    Console.WriteLine($"{example.GetValue(i):####.####}");
                }
                finally
                {
                    pool.Return(example);
                }

                if (cts.Token.IsCancellationRequested)
                {
                    loopState.Stop();
                }
            });

            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();
        }
    }

    // A toy class that requires some resources to create.
    // You can experiment here to measure the performance of the
    // object pool vs. ordinary instantiation.
    class ExampleObject
    {
        public int[] Nums { get; set; }

        public ExampleObject()
        {
            Nums = new int[1000000];
            var rand = new System.Random();
            for (int i = 0; i < Nums.Length; i++)
            {
                Nums[i] = rand.Next();
            }
        }

        public double GetValue(long i) => Math.Sqrt(Nums[i]);
    }
}
