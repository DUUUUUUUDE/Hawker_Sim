using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : Action
{

    protected override void Start()
    {
        base.Start();
        Type = CombinationDicctionary.Actions.Craft;
    }

}
