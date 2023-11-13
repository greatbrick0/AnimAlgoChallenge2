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
        gameObject.GetComponent<Animator>().SetTrigger("Walk");
        agent = gameObject.GetComponent<NavMeshAgent>();
        gameObject.GetComponent<Biter>().currentPatrolPoint += 1;
        agent.SetDestination(gameObject.GetComponent<Biter>().GetNextRoutePoint());
    }

    public override void Update()
    {
        if(Vector3.Distance(agent.pathEndPosition, transform.position) < 1)
        {
            if (gameObject.GetComponent<Biter>().currentPatrolPoint == 2 && Vector3.Distance(transform.position, new Vector3(-15, 1, 15)) < 3)
            {
                MakeTransition(TEnumTransition.START_ATTACK);
            }
            else MakeTransition(TEnumTransition.START_WANDER);

        }
    }

    public override void Exit()
    {
        gameObject.GetComponent<AWSPatrol>().interruptPatrol = true;
    }
}
