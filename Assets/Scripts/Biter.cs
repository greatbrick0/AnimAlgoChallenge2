using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;
using Worq;

public class Biter : MonoBehaviour
{
	private StateMachine<Biter, TEnumState, TEnumTransition> m_FSM;
	public StateMachine<Biter, TEnumState, TEnumTransition> FSM
	{
		get { return m_FSM; }
	}

	public WaypointRoute routePoints;

	public int currentPatrolPoint = 0;

	public TEnumState m_InitialState;

	public ScriptableObject[] m_States;

	public Vector3 GetNextRoutePoint()
    {
		return routePoints.GetChildPoint(currentPatrolPoint);
    }

	void OnDestroy()
	{
		m_FSM.Destroy();
	}

	void Start()
	{
		m_FSM = new StateMachine<Biter, TEnumState, TEnumTransition>(this, m_States, m_InitialState);
	}

	void Update()
	{
		m_FSM.Update();
	}

	void FixedUpdate()
	{
		m_FSM.FixedUpdate();
	}

	void OnTriggerEnter(Collider col)
	{
		m_FSM.OnTriggerEnter(col);
	}
}
