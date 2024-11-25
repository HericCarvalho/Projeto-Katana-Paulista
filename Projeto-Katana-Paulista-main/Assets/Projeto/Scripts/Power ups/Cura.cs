using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : PowerUp1
{
    public float amount;
    public override void Apply(GameObject target)
    {
        //target.GetComponent<PlayerHealth>().health.value += amount;
    }
}
