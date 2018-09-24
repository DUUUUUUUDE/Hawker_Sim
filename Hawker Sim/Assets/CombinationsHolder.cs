using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationsHolder : MonoBehaviour {

    public static CombinationsHolder _Combiations;

    public enum Type { Human, Principle, Vessel, Ingridient, Location, Product, Order};
    public enum _Action { Shop, Combine, Talk, Explore, Study}
    public enum _Principle { Stone, Light, Nature, Owl, Arcana, Death};
    public enum _Vessel { Weapon, Paper, Vial, Tool};

    private void Awake()
    {
        _Combiations = this;
    }

    public void SetUpAction ()
    {

    }

}
