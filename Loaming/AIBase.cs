using UnityEngine;

class AIBase : MonoBehaviour
{
	[SerializeField] private MoveController m_Mover;
	[SerializeField] private PatrolPath m_PatrolPath;

	[SerializeField] float m_WaypointTolerance = 0.1f;
	[SerializeField] float m_WaypointDwellTime = 3f;

	int m_CurrentWaypointIndex = 0;
	float m_TimeSinceArraivedAtWaypoint = Mathf.Infinity;

	void Start()
	{
		if (!m_Mover)
			m_Mover = GetComponent<MoveController>();
	}

	void Update()
	{
		m_TimeSinceArraivedAtWaypoint += Time.deltaTime;

		Loaming();
	}

	private void Loaming()
	{
		if (m_PatrolPath == null)
			return;

		if (reachedWaypoint())
		{
			m_CurrentWaypointIndex = m_PatrolPath.GetNextIndex(m_CurrentWaypointIndex);
			m_Mover.m_IsMoving = false;

			m_TimeSinceArraivedAtWaypoint = 0;
		}
		else if (m_TimeSinceArraivedAtWaypoint > m_WaypointDwellTime)
		{
			m_Mover.MoveTo(m_PatrolPath.GetWaypoint(m_CurrentWaypointIndex));
			m_Mover.m_IsMoving = true;
		}
	}

	private Vector3 GetCurrentWaypoint()
	{
		return m_PatrolPath.GetWaypoint(m_CurrentWaypointIndex);
	}
	private bool reachedWaypoint()
	{
		float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
		return distanceToWaypoint < m_WaypointTolerance;
	}

}
