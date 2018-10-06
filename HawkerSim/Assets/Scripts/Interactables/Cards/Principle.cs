using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principle : Card
{

    public CombinationDicctionary.Principles PrincipleType;

    protected override void Start()
    {
        Type = CombinationDicctionary.Cards.Principle;
    }

}
