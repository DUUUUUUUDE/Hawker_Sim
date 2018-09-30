using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInGame : MonoBehaviour {

    private static ManagerInGame instance;
    public static ManagerInGame Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SetUpGame();
    }

    private void SetUpGame()
    {
        GetClasses();
        M_Interactable.GetAllInteractables();
    }



    #region CLASSES

    void GetClasses ()
    {
        m_camera = FindObjectOfType<ManagerCamera>();
        m_interactable = FindObjectOfType<ManagerInteractables>();
        m_combDictionary = FindObjectOfType<CombinationDicctionary>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private static ManagerCamera m_camera;
    public static ManagerCamera M_Camera
    {
        get
        {
            return m_camera;
        }
    }

    private static ManagerInteractables m_interactable;
    public static ManagerInteractables M_Interactable
    {
        get
        {
            return m_interactable;
        }
    }

    private static CombinationDicctionary m_combDictionary;
    public static CombinationDicctionary M_CombDictionary
    {
        get
        {
            return m_combDictionary;
        }
    }

    private static PlayerInput _playerInput;
    public static PlayerInput _PlayerInput
    {
        get
        {
            return _playerInput;
        }
    }

    #endregion
}
