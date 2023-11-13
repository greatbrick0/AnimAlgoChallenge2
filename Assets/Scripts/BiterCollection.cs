using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiterCollection : MonoBehaviour
{
    public List<Biter> collectedBiters = new List<Biter>();

    public Biter GiveBiter()
    {
        if(collectedBiters.Count > 0)
        {
            Biter output = collectedBiters[0];
            collectedBiters.RemoveAt(0);
            return output;
        }
        else return null;
    }
}
