using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    public static Bird instance;

    private Rigidbody2D myRigidbody;

    private Animator anim;

    private float forwordSpeed=3f;
    private float bounceSpeed=4f;

    private Button FlapButton;
    private bool didFlap;
    public bool isAlive;
    private void Awake()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        FlapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();

        FlapButton.onClick.AddListener(FlapTheBird);

        if(instance == null)
        {
            instance = this; 
        }

        isAlive = true;

        setCameraX();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(isAlive)
        {  
           // print(transform.position);
            Vector3 temp = transform.position;
            temp.x += forwordSpeed * Time.deltaTime;
            transform.position = temp;

            //print(Time.timeScale);
           // print(myRigidbody.velocity.y);
           // print(temp.x);
            if(didFlap)
            {
                didFlap = false;
                myRigidbody.velocity = new Vector2(0,bounceSpeed);
                anim.SetTrigger("Flap");
            }

            if(myRigidbody.velocity.y >=0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myRigidbody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

        }
    }

    void setCameraX()
    {
        CameraFollow.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }
}
