using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
        //get
        //{
        //    if (instance == null)
        //    {
        //        instance = FindObjectOfType<T>();
        //    }
        //    else if (instance != FindObjectOfType<T>())
        //    {
        //        Destroy(FindObjectOfType<T>());
        //    }
        //    return instance;
        //}
    }

    //static public GameManager Instance
    //{
    //    get
    //    {
    //        return instance;
    //    }
    //}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //DontDestroyOnLoad(gameObject); 
    }

}
