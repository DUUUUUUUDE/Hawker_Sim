using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    public List<Transform> ranures = new List<Transform> ();

    public List<Card> Cards = new List<Card> ();

    bool Reciving;

    private void Start()
    {
        foreach (Transform t in GetComponentsInChildren <Transform>(true))
        {
            if (t != this.transform)
                ranures.Add(t);
        }
    }

    public void ActivateRanures ()
    {
        foreach (Transform t in ranures)
        {
            t.gameObject.SetActive(true);
        }
    }

    public void DeactivateRanures ()
    {
        if (!Reciving)
        {
            foreach (Transform t in ranures)
            {
                t.gameObject.SetActive(false);
            }
        }
    }

   public int numberOfCards = 0;

    public void GetCard(Card card)
    {
        if (numberOfCards < ranures.Capacity)
        {
            card.GetComponent<Rigidbody2D>().isKinematic = true;
            Cards.Add(card);
            foreach (Transform t in ranures)
            {
                if (!t.GetComponentInChildren<Card>())
                {
                    card.transform.parent = t;
                    break;
                }
            }
            card.transform.localPosition = Vector3.zero;
            card.PutOnAction(this);
            numberOfCards++;
            Reciving = true;
        }
    }

    public void GiveUpCard (Card card)
    {
        Cards.Remove(card);
        card.transform.parent = null;
        numberOfCards--;
    }

}
