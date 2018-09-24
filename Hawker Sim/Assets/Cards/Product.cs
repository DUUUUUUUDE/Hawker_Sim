using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : Card {

    public enum TypeVessel
    {
        Weapon,
        Tool,
        Vial,
        Paper
    };

    public TypeVessel _Vessel;

    public bool Special;

    public enum TypePrinciple
    {
        Stone,
        Light,
        Nature,
        Owl,
        Arcane,
        Dark,
    };

    public TypePrinciple _Principle;

    public int level;
}
