using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private const string HIGH_SCORE = "XX";
    private const string SELECT_BIRD = "select bird";
    private const string GREEN_BIRD = "green bird";
    private const string RED_BIRD = "red bird";


    private void Awake()
    {
        MakeSingleton();
    }

    /// <summary>
    /// this method is use for instance , if instance != null so destroy object , if not so set instance and use dontdestroyonload
    /// </summary>
    void MakeSingleton()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
