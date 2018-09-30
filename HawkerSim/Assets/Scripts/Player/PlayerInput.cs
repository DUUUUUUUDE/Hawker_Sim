using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private void Update()
    {
        if (!WaitingMouseCheck)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(HoldMouseCheck(Input.mousePosition));
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                ManagerInGame.M_Interactable.DeselectObject();
            }
        }
    }

    public bool AlignIsPressed()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }


    bool WaitingMouseCheck;
    IEnumerator HoldMouseCheck(Vector3 pos)
    {
        WaitingMouseCheck = true;

        yield return new WaitForSeconds(0.15f);

        ManagerInGame.M_Interactable.SelectObject (pos);

        if (ManagerInGame.M_Interactable.Target != null)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //HOLD MOUSE
                ManagerInGame.M_Interactable.HardSelection();
            }
            else
            {
                //1 CLICK
                ManagerInGame.M_Interactable.SoftSelection();
            }
        }

        WaitingMouseCheck = false;
    }
}
