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
        IsTheGameStartedForTheFirstTime();
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

    void IsTheGameStartedForTheFirstTime()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefsManager.FirstTimeGame))
        {
            PlayerPrefs.SetInt(HIGH_SCORE,0);
            PlayerPrefs.SetInt(SELECT_BIRD, 0);
            PlayerPrefs.SetInt(GREEN_BIRD, 1);
            PlayerPrefs.SetInt(RED_BIRD, 1);
            PlayerPrefs.SetInt(PlayerPrefsManager.FirstTimeGame,0);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void SetSelectedBird(int Bird)
    {
        PlayerPrefs.SetInt(SELECT_BIRD, Bird);
    }
    public int GetSelectedBird()
    {
        return PlayerPrefs.GetInt(SELECT_BIRD);
    }

    public void UnlockGreenBrid()
    {
        PlayerPrefs.SetInt(GREEN_BIRD, 1);
    }

    public int IsGreenBridUnlock()
    {
        return PlayerPrefs.GetInt(GREEN_BIRD);
    }
    public void UnlockRedBrid()
    {
        PlayerPrefs.SetInt(RED_BIRD, 1);
    }

    public int IsRedBridUnlock()
    {
        return PlayerPrefs.GetInt(RED_BIRD);
    }

}
