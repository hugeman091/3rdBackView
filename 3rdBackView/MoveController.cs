using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveController : MonoBehaviour
{
	[SerializeField] LocomotionController m_Locomotion;

	public float m_RotateSpeed = 10f;
	public float m_MoveSpeed = 3f;
	public NavMeshAgent m_NavmeshAgent;

	public bool m_IsMoving;

	private Vector3 m_Dest;
	private Vector3 m_Dir;


	private void Start()
	{
		if (!m_NavmeshAgent)
		{
			m_NavmeshAgent = GetComponent<NavMeshAgent>();
			//constant speed 내고싶어서 강제로 세팅
			m_NavmeshAgent.acceleration = 1000;
			m_NavmeshAgent.angularSpeed = 360;
			m_NavmeshAgent.isStopped = false;
		}
		
		if (!m_Locomotion)
			m_Locomotion = GetComponent<LocomotionController>();
	}

	void Update()
	{
		RunAnimation();
	}

	private void RunAnimation()
	{
		m_Locomotion.RunAnimation(m_IsMoving, m_MoveSpeed);
	}

	public void MoveTo(Vector3 dir, bool move)
	{
		m_IsMoving = move;

		if (!m_IsMoving)
			return;

		m_Dest = transform.position + dir * m_MoveSpeed * Time.deltaTime;
		m_NavmeshAgent.nextPosition = m_Dest;
		m_NavmeshAgent.speed = m_MoveSpeed;
	}

	public void MoveTo(Vector3 dest)
	{
		m_NavmeshAgent.SetDestination(dest);
		m_NavmeshAgent.speed = m_MoveSpeed;
	}


}
