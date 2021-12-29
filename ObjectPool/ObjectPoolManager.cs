using System.Collections.Generic;
using ClientCore;

public class ObjectPoolManager
{
	private Dictionary<string, ObjectPool> _pools = new Dictionary<string, ObjectPool>();
	public ObjectPool Pool(string id)
	{
		ObjectPool pool;
		_pools.TryGetValue(id, out pool);
		if (pool == null)
		{
			pool = new ObjectPool();
			_pools.Add(id, pool);
			return pool;
		}

		return pool;
	}

	public void Clear(string id)
	{
		if (_pools.ContainsKey(id))
			_pools.Remove(id);
	}
}