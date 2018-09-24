using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    [TextArea (10,10)]
    public List<string> Descrpitions = new List<string>();

    public CombinationsHolder.Type _TYPE;
    public int _LEVEL;

    [HideInInspector]
    public bool onAction;
    Action action;

    public void PutOnAction (Action _action)
    {
        action = _action;
        onAction = true;
        GetComponent<SpriteRenderer>().sortingOrder = 9;
    }

    public void RemoveFromAction()
    {
        action.GiveUpCard(this);
        action = null;
        onAction = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Action>())
        {
            collision.gameObject.GetComponent<Action>().ActivateRanures();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (collision.gameObject.GetComponent<Action>())
            {
                collision.gameObject.GetComponent<Action>().GetCard (this);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Action>())
        {
            collision.gameObject.GetComponent<Action>().DeactivateRanures();
        }
    }
}
