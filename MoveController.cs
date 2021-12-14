using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MoveController : MonoBehaviour
{

	public float m_RotateSpeed = 10f;
	public float m_MoveSpeed = 3f;
	public NavMeshAgent m_NavmeshAgent;
	public bool m_IsMoving;

	private Vector3 m_Dest;
	private Vector3 m_Dir;

	private void Start()
	{
		if (!m_NavmeshAgent)
			m_NavmeshAgent = GetComponent<NavMeshAgent>();
	}
	private void FixedUpdate()
	{
		Move();
	}
	private void Move()
	{
		m_NavmeshAgent.nextPosition = m_Dest;
	}


	public void MoveTo(Vector3 dir, bool move)
	{
		m_IsMoving = move;

		if (!m_IsMoving)
			return;

		m_Dir = dir;
		m_Dest = transform.position + dir * m_MoveSpeed * Time.deltaTime;

		//constant speed 내고싶어서 강제로 세팅
		m_NavmeshAgent.acceleration = 1000;
		m_NavmeshAgent.speed = m_MoveSpeed;
		m_NavmeshAgent.angularSpeed = 360;
	}
}
