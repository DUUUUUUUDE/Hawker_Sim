using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour {

    public InteractableOBJ OnMouseOBJ;

    Camera MainCamera;

    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;
    
    private void Awake()
    {
        MainCamera = Camera.main;
    }

    void Update()
    {
        
        //MOVE OBJECTS
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(MainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                OnMouseOBJ = hit.collider.GetComponent<InteractableOBJ>();
                OnMouseOBJ.PickUp();
                OnMouseOBJ.GetComponent<SpriteRenderer>().sortingOrder = 10;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && OnMouseOBJ)
        {
            OnMouseOBJ.GetComponent<SpriteRenderer>().sortingOrder = 0;
            OnMouseOBJ.Drop();
            OnMouseOBJ = null;
        }

        if (OnMouseOBJ != null)
        {
            OnMouseOBJ.transform.position = new Vector2(MainCamera.ScreenToWorldPoint(Input.mousePosition).x, MainCamera.ScreenToWorldPoint(Input.mousePosition).y);
        }

        //ZOOM
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            MainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 2;
            if (MainCamera.orthographicSize > 10)
                MainCamera.orthographicSize = 10;
            else if (MainCamera.orthographicSize < 4)
                MainCamera.orthographicSize = 4;
            else
                MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(MainCamera.ScreenToWorldPoint(Input.mousePosition).x, MainCamera.ScreenToWorldPoint(Input.mousePosition).y, MainCamera.transform.position.z), 100 * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"));

        }

        //CAMERA DRAG
        if (Input.GetMouseButton(1))
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            Camera.main.transform.position = Origin - Diference;
        }


    }
}
