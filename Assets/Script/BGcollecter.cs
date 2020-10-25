using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGcollecter : MonoBehaviour
{
    private GameObject[] background;
    private GameObject[] ground;

    private float lastBGx;
    private float lastGroundx;

    private void Awake()
    {
        background = GameObject.FindGameObjectsWithTag("Background");
        ground = GameObject.FindGameObjectsWithTag("Ground");

        lastBGx = background[0].transform.position.x;
        lastGroundx = ground[0].transform.position.x;

        for(int i=1;i<background.Length;i++)
        {
            if(lastBGx<background[i].transform.position.x)
            {
                lastBGx = background[i].transform.position.x;
            }
        }
        
        for(int i=1;i<ground.Length;i++)
        {
            Debug.LogError(ground.Length);
            if(lastGroundx < ground[i].transform.position.x)
            {
                lastGroundx = ground[i].transform.position.x;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;
            print("---" + width + "---" + "----" + lastBGx + "-----");
            temp.x = lastBGx + width;

            target.transform.position = temp;

            lastBGx = temp.x;
        }
        if (target.tag=="Ground")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;
            print("---"+width+"---"+"----"+lastGroundx+"-----");
            temp.x = lastGroundx + width;

            target.transform.position = temp;

            lastGroundx = temp.x;
        }
    }
}
