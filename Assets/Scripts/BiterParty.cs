using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiterParty : BiterCollection
{
    [SerializeField]
    float pullTime = 7.0f;
    [SerializeField]
    int fullPartySize = 4;

    [SerializeField]
    BiterCollection biterSource;

    void Start()
    {
        InvokeRepeating(nameof(PullBiter), 7.0f, pullTime);
    }

    void PullBiter()
    {
        collectedBiters.Add(biterSource.GiveBiter());
        collectedBiters[^1].FSM.MakeTransition(TEnumTransition.START_TRAVEL);
    }

    private void Update()
    {
        if (collectedBiters.Count >= fullPartySize) SendBiters();
    }

    void SendBiters()
    {
        List<Biter> readyBiters = new List<Biter>();
        foreach (Biter biter in collectedBiters)
        {
            if (biter.FSM.CurrentStateName == "StateBiterWander") readyBiters.Add(biter);
        }
        if (readyBiters.Count < fullPartySize) return;
        foreach (Biter biter in readyBiters)
        {
            print(biter.FSM.CurrentState);
            collectedBiters.Remove(biter);
            biter.FSM.MakeTransition(TEnumTransition.START_TRAVEL);
        }
        
    }
}
