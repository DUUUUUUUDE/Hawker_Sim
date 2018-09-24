using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : Action {

    public GameObject _Product;

    public override void MakeAction()
    {
        CraftProduct(Cards [0],Cards [1]);
    }

    public void CraftProduct(Card A, Card B)
    {

        Card C = null;

        if (!A.GetComponent<Vessel>())
        {
            C = A;
            A = B;
            B = C;
        }

        GameObject newProduct = Instantiate(_Product);
        Product pt = newProduct.GetComponent<Product>();
        pt._VESSEL = A.GetComponent<Vessel>()._VESSEL;
        pt._PRINCIPLE = B.GetComponent<Principle>()._PRINCIPLE;
        pt._LEVEL = B._LEVEL;

    }
    
}
