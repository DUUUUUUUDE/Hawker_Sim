using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInteractables : MonoBehaviour {

    public float InteractionDist = 3;
    public float roundMultiplier = 1;

    #region Select Deselect Interactables

    public Interactable Target;

    //SELECT DESELECT Object
    public void SelectObject (Vector3 mousePos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Interactable>())
            {
                Target = hit.collider.GetComponent <Interactable>();
                RearrangeInteractables();
            }
        }
        else
        {
            if (Target) DeselectObject();
        }
    }
    public void DeselectObject()
    {
        if (Target)
        {
            if (TargetAction && Target.GetComponent<Card>())
            {
                if (ManagerInGame.M_CombDictionary.CheckSlotOptions(TargetAction, Target.GetComponent<Card>()))
                {
                    if (Vector3.Distance(TargetAction.transform.position, Target.transform.position) < InteractionDist)
                    {
                        TargetAction.AddCard (Target.GetComponent<Card>());
                    }
                }
            }
            Target = null;
        }
    }

    //SELECTION TYPES
    public void SoftSelection ()
    {
        Debug.Log(Target.ObjectDescription);
    }
    public void HardSelection ()
    {
        MoveInteractable = StartCoroutine(MoveInteractableCO());
        if (Target.GetComponent<Card>() && TargetAction)
        {
            if (TargetAction.Cards.Contains(Target.GetComponent<Card>()))
            {
                TargetAction.RemoveCard(Target.GetComponent<Card>());
            }
        }
    }

    #endregion


    #region Arrange Interactables

    public List<Interactable> AllInteractables = new List<Interactable>();
    List<Action> AllActions = new List<Action>();
    List<Card> AllCards = new List<Card>();

    //GET INTERACTABLES 
    public void GetAllInteractables ()
    {
        int orderInLayer = 0;
        foreach (Interactable I in FindObjectsOfType<Interactable>())
        {
            I.GetComponent<SpriteRenderer>().sortingOrder = ++orderInLayer;
            AllInteractables.Add(I);
            if (I.GetComponent<Action>()) AllActions.Add(I.GetComponent<Action>());
            if (I.GetComponent<Card>()) AllCards.Add(I.GetComponent<Card>());
        }
    }

    //ADD OR REMOVE INTERACTABLE
    public void AddInteractable (Interactable newInteractable)
    {
        AllInteractables.Add(newInteractable);
        if (newInteractable.GetComponent<Action>()) AllActions.Add(newInteractable.GetComponent<Action>());
        if (newInteractable.GetComponent<Card>()) AllCards.Add(newInteractable.GetComponent<Card>());
    }
    public void RemoveInteractable (Interactable newInteractable)
    {
        AllInteractables.Remove(newInteractable);
        if (newInteractable.GetComponent<Action>()) AllActions.Remove(newInteractable.GetComponent<Action>());
        if (newInteractable.GetComponent<Card>()) AllCards.Remove(newInteractable.GetComponent<Card>());
    }

    void RearrangeInteractables ()
    {
        AllInteractables.Remove(Target);
        AllInteractables.Add(Target);

        int orderInLayer = 0;
        foreach (Interactable I in AllInteractables)
            I.GetComponent<SpriteRenderer>().sortingOrder = ++orderInLayer;

    }

    #endregion


    #region Move Target

    //MOVE SELECTED INTERACTABLE
    Coroutine MoveInteractable;
    IEnumerator MoveInteractableCO()
    {
        while (Target)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (ManagerInGame._PlayerInput.AlignIsPressed ())
                Target.transform.position = new Vector3 (RoundNunmber (mousePos.x) , RoundNunmber (mousePos.y), 0);
            else
                Target.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

            bool cardOnAction = false;
            if (Target.GetComponent<Card>())
            {
                foreach (Action A in AllActions)
                {
                    if (A.Cards.Count > 0)
                    {
                        cardOnAction = true;
                    }
                }
            }
            if (!cardOnAction) CheckForAction();

            yield return null;
        }
    }

    float RoundNunmber(float value)
    {
        int intValue = (int)(value * roundMultiplier);
        return intValue / roundMultiplier;
    }

    //ACTION CHECKER
    Action TargetAction;
    void CheckForAction()
    {
        Action ActionHolder = null;
        float interactionDist = InteractionDist-0.5f;
        foreach (Action A in AllActions)
        {
            if (Vector3.Distance(Target.transform.position, A.transform.position) < interactionDist)
            {
                interactionDist = Vector3.Distance(Target.transform.position, A.transform.position);
                ActionHolder = A;
            }
        }

        

        if (ActionHolder && !TargetAction)
        {
            TargetAction = ActionHolder;
            TargetAction.Activate();
        }
        else if (!ActionHolder && TargetAction)
        {
            TargetAction.Deactivate();
            TargetAction = null;
        }

        if (ActionHolder != TargetAction)
        {
            TargetAction.Deactivate();
            TargetAction = ActionHolder;
            TargetAction.Activate();
        }

    }

    #endregion

}
