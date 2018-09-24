using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : Card {

    public CombinationsHolder._Vessel _VESSEL;

    void Start()
    {
        _TYPE = CombinationsHolder.Type.Vessel;
    }
}
