using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBridUnlock, isRadBridUnlock;


    private void Awake()
    {
        MakeInstance();
    }
    private void Start()
    {
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        CheckIsBridUnlocked();
    }

    private void MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void CheckIsBridUnlocked()
    {
        if(GameController.instance.IsRedBridUnlock()==1)
        {
            isRadBridUnlock = true;
        }
        if(GameController.instance.IsGreenBridUnlock()==1)
        {
            isGreenBridUnlock = true;
        }
    }

    public void ChangeBird()
    {
        if(GameController.instance.GetSelectedBird()==0)
        {
            if(isGreenBridUnlock)
            {
                birds[0].SetActive(false);
                GameController.instance.SetSelectedBird(1);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        }
        else if(GameController.instance.GetSelectedBird()==1)
        {
            if (isRadBridUnlock)
            {
                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(0);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
            
        }
    }
}
