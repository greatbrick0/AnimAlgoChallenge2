using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Worq;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/Wander")]
public class StateBiterWander : BehaviourState
{
    private NavMeshAgent agent;
    private Vector3 originPos;

    public override void BuildTransitions()
    {
        AddTransition(TEnumTransition.START_ATTACK, TEnumState.ATTACK);
        AddTransition(TEnumTransition.START_TRAVEL, TEnumState.TRAVEL);
    }

    public override void Enter()
    {
        originPos = transform.position;
        gameObject.GetComponent<Animator>().SetTrigger("Idle");
        agent = gameObject.GetComponent<NavMeshAgent>();
        StartCoroutine(WanderRandomly());
    }

    private IEnumerator WanderRandomly()
    {
        agent.SetDestination(originPos + (Vector3.forward * Random.Range(-6, 6)) + (Vector3.right * Random.Range(-6, 6)));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(WanderRandomly());
    }

    public override void Exit()
    {
        StopAllCoroutines();
    }
}
