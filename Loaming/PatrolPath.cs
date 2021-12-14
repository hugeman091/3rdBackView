using UnityEngine;

class PatrolPath : MonoBehaviour
{
	void OnDrawGizmos()
	{
		const float mWaypointGizmoRadius = 0.3f;

		for (int i = 0; i < transform.childCount; ++i)
		{
			int j = GetNextIndex(i);
			Gizmos.DrawSphere(GetWaypoint(i), mWaypointGizmoRadius);
			Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
		}
	}

	public int GetNextIndex(int i)
	{
		if (i + 1 == transform.childCount)
			return 0;
		return i + 1;
	}

	public Vector3 GetWaypoint(int i)
	{
		return transform.GetChild(i).position;
	}
}
