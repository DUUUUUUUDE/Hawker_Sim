using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    public CombinationDicctionary.Actions Type;
    public List<Card> Cards;

    List<Transform> CardHolders = new List<Transform> ();
    float radius;

    public List<List<CombinationDicctionary.Cards>> Combinations = new List<List<CombinationDicctionary.Cards>>();



    protected virtual void Start()
    {
        foreach (Transform T in GetComponentsInChildren<Transform>(true))
        {
            if (T.name == "Card Holder")
            {
                CardHolders.Add(T);
            }
        }
    }
    
    #region Activate Deactivate
    public void Activate ()
    {
        GetComponent<SpriteRenderer>().color = Color.grey;
    }
    public void Deactivate ()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    #endregion

    #region Add/remove Card
    public void AddCard(Card card)
    {
        Transform holder = null;

        foreach (Transform T in CardHolders)
        {
            if (!T.gameObject.activeSelf)
            {
                holder = T;
                break;
            }
        }

        if (holder)
        {
            Cards.Add(card);
            holder.gameObject.SetActive(true);
            holder.transform.position = GetNewHolder(CardHolders.IndexOf (holder));
            holder.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;

            card.transform.parent = holder;
            card.transform.localPosition = Vector3.zero;
        }
    }

    public void RemoveCard (Card card)
    {
        card.transform.parent.gameObject.SetActive(false);
        card.transform.parent = null;
        card.gameObject.SetActive(true);
        Cards.Remove(card);
    }

    Vector3 GetNewHolder(int HolderNum)
    {
        float angle = (360 / 5) * HolderNum;
        Vector3 pos;
        pos.x = transform.position.x + radius + Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = transform.position.y + radius + Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = transform.position.z;
        return pos;
    }
    #endregion

}
