using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationDicctionary : MonoBehaviour {

    #region ENUMS

    public enum Cards
    {
        Principle,
        Vessel,
        Product,
        Order,
        KnownNPC,
        VIP,
        Location,
        Knowledge,
        InfoNotes,
        Event,
        Ingridient,
        P_Stone,
        P_Light,
        P_Nature,
        P_Owl,
        P_Arcana,
        P_Death,
        V_Weapon,
        V_Tool,
        V_Paper,
        V_Vial
    }; 

    public enum Actions
    {
        Talk,       //0
        Explore,    //1
        Shop,       //2
        Craft,      //3
        Study       //4
    };

    #endregion


    // CHECKERS
    public bool CheckSlotOptions (Action action, Card card)
    {
        switch (action.Type)
        {
            case Actions.Craft:
                return (card.Type == Cards.Principle) 
                    || (card.Type == Cards.Vessel) 
                    || (card.Type == Cards.Knowledge);
            case Actions.Explore:
                return (card.Type == Cards.Location);
            case Actions.Shop:
                return (card.Type == Cards.Order);
            case Actions.Study:
                return (card.Type == Cards.Order)
                    || (card.Type == Cards.KnownNPC)
                    || (card.Type == Cards.VIP)
                    || (card.Type == Cards.Location)
                    || (card.Type == Cards.Event)
                    || (card.Type == Cards.Ingridient);
            case Actions.Talk:
                return (card.Type == Cards.Order)
                    || (card.Type == Cards.KnownNPC)
                    || (card.Type == Cards.Event);
        }
        return false;
    }




}
