using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private bool isJumping = false;
    private bool isPunching = false;
    private bool isBuilding = false;

    public bool IsJumping
    {
        get
        {
            return isJumping;
        }
        set
        {
            isJumping = value;
        }
    }

    public bool IsPunching
    {
        get
        {
            return isPunching;
        }
        set
        {
            isPunching = value;
        }
    }

    public bool IsBuilding
    {
        get
        {
            return isBuilding;
        }
        set
        {
            isBuilding = value;
        }
    }

    public void jumpBtnPressed()
    {
        IsJumping = true;
    }

    public void punchBtnPressed()
    {
        IsPunching = true;
    }

    public void buildBtnPressed()
    {
        IsBuilding = true;
    }

    static public GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //DontDestroyOnLoad(gameObject); 
    }
}
