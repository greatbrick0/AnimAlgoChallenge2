using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Worq;

[CreateAssetMenu(menuName = "States/Attack")]
public class StateBiterAttack : BehaviourState
{
    private float age = 0.0f;
    public override void BuildTransitions()
    {
        AddTransition(TEnumTransition.START_TRAVEL, TEnumState.TRAVEL);
        AddTransition(TEnumTransition.START_WANDER, TEnumState.WANDER);
    }

    public override void Enter()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Basic Attack");
        age = 0;
    }

    public override void Update()
    {
        age += Time.deltaTime;
        if (age >= 5) Destroy(gameObject);
    }
}
