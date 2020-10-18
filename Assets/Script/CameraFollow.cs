using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static float offsetX;

    private void Update()
    {
        if(Bird.instance !=null)
        {
            if(Bird.instance.isAlive)
            {
                moveCamera();
            }
        }
    }
    public void moveCamera()
    {
        Vector3 temp = transform.position;
        temp.x = Bird.instance.GetPositionX()+ offsetX;
        transform.position = temp;
    }
}
