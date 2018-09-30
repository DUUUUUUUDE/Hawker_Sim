using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Action
{

    protected override void Start()
    {
        base.Start();
        Type = CombinationDicctionary.Actions.Shop;
    }

}
