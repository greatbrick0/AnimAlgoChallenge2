using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

public enum TEnumState
{
	WANDER,
	TRAVEL,
	ATTACK,
}

public enum TEnumTransition
{
	START_WANDER,
	START_TRAVEL,
	START_ATTACK,
}

public class BehaviourState : State<Biter, TEnumState, TEnumTransition>
{
	public override void BuildTransitions()
	{

	}

	public override void Enter()
	{

	}

	public override void Exit()
	{

	}

	public override void FixedUpdate()
	{

	}

	public override void Update()
	{

	}
}
