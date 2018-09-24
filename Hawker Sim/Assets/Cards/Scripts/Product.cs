using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : Card {

    public CombinationsHolder._Vessel _VESSEL;
    public CombinationsHolder._Principle _PRINCIPLE;

    void Start()
    {
        _TYPE = CombinationsHolder.Type.Vessel;
    }
}
