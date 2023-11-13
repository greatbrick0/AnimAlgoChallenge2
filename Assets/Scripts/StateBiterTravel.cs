using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Worq;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/Travel")]
public class StateBiterTravel : BehaviourState
{
    private NavMeshAgent agent;

    public override void BuildTransitions()
    {
        AddTransition(TEnumTransition.START_ATTACK, TEnumState.ATTACK);
        AddTransition(TEnumTransition.START_WANDER, TEnumState.WANDER);
    }

    public override void Enter()
    {
        gameObject.GetComponent<AWSPatrol>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("Walk");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public override void Update()
    {
        if(Vector3.Distance(agent.pathEndPosition, transform.position) < 1)
        {
            MakeTransition(TEnumTransition.START_WANDER);
        }
    }

    public override void Exit()
    {
        gameObject.GetComponent<AWSPatrol>().interruptPatrol = true;
    }
}
