using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Worq;

[CreateAssetMenu(menuName = "States/Attack")]
public class StateBiterAttack : BehaviourState
{
    public override void BuildTransitions()
    {
        AddTransition(TEnumTransition.START_TRAVEL, TEnumState.TRAVEL);
        AddTransition(TEnumTransition.START_WANDER, TEnumState.WANDER);
    }

    public override void Enter()
    {
        gameObject.GetComponent<AWSPatrol>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("Attack");
    }
}
