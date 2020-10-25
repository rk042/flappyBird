using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollecter : MonoBehaviour
{
    private GameObject[] PipeHolders;
    private float distance = 5f;

    private float lastPipesx;
    private float pipeMin =-2f;
    private float pipeMax =3f; 



    private void Awake()
    {
        PipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

        for(int i =0;i < PipeHolders.Length; i++)
        {
            Vector3 temp = PipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            PipeHolders[i].transform.position = temp;
        }

        lastPipesx = PipeHolders[0].transform.position.x;

        for (int i = 1; i < PipeHolders.Length; i++)
        {
           if(lastPipesx<PipeHolders[i].transform.position.x)
            {
                lastPipesx = PipeHolders[i].transform.position.x;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag =="PipeHolder")
        {
            Vector3 temp = target.transform.position;
            temp.x = lastPipesx + distance;
            temp.y = Random.Range(pipeMin, pipeMax);

            target.transform.position = temp;

            lastPipesx = temp.x; 
        }
    }
}
