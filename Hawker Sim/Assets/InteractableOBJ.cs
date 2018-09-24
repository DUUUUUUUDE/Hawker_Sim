using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class InteractableOBJ : MonoBehaviour
{

    public void PickUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        if (GetComponent<Card>())
        {
            if (GetComponent<Card>().onAction)
            {
                GetComponent<Card>().RemoveFromAction();
            }
        }
    }

    public void Drop()
    {
        StartCoroutine(DropCO());
    }

    IEnumerator DropCO()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void Awake()
    {
        GetComponent<BoxCollider2D>().autoTiling = true;
    }
    


}
