using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : Action
{

    protected override void Start()
    {
        base.Start();
        Type = CombinationDicctionary.Actions.Explore;
    }

}
