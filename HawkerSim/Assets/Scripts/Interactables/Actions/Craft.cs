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

    //CHECK FIRST TYPE
    void CheckCombination ()
    {
        switch (Cards[0].Type)
        {
            case (CombinationDicctionary.Cards.Principle):
                if (Cards[1].Type == CombinationDicctionary.Cards.Principle)
                {
                    CheckPrincipleCombination(Cards[0].GetComponent<Principle>());
                }
                break;
            case (CombinationDicctionary.Cards.Vessel):
                if (Cards[1].Type == CombinationDicctionary.Cards.Vessel)
                {
                    MakeProduct();
                }
                break;
            case (CombinationDicctionary.Cards.Knowledge):
                break;
        }
    }

    //COMBINE PRINCIPLES
    void CheckPrincipleCombination (Principle principle)
    {

        CombinationDicctionary.Principles secondCard = Cards[1].GetComponent<Principle>().PrincipleType;

        switch (principle.PrincipleType)
        {
            case (CombinationDicctionary.Principles.Arcana):
                if (secondCard == CombinationDicctionary.Principles.Death || secondCard == CombinationDicctionary.Principles.Light)
                {
                    // LVL UP
                }
                break;
            case (CombinationDicctionary.Principles.Death):
                //LVL UP
                break;
            case (CombinationDicctionary.Principles.Light):
                if (secondCard == CombinationDicctionary.Principles.Arcana)
                {
                    //LVL UP
                }
                break;
            case (CombinationDicctionary.Principles.Nature):
                if (secondCard == CombinationDicctionary.Principles.Owl || secondCard == CombinationDicctionary.Principles.Death)
                {
                    //LVL UP
                }
                break;
            case (CombinationDicctionary.Principles.Owl):
                if (secondCard == CombinationDicctionary.Principles.Arcana || secondCard == CombinationDicctionary.Principles.Stone)
                {
                    //LVL UP
                }
                break;
            case (CombinationDicctionary.Principles.Stone):
                if (secondCard == CombinationDicctionary.Principles.Light || secondCard == CombinationDicctionary.Principles.Owl)
                {
                    //LVL UP
                }
                break;
        }
    }

    void MakeProduct ()
    {

    }

}
