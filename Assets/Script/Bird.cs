using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    public static Bird instance;

    private Rigidbody2D myRigidbody;
    private AudioSource audioSource;

    private Animator anim;

    private float forwordSpeed=3f;
    private float bounceSpeed=4f;

    private Button FlapButton;
    private bool didFlap;
    public bool isAlive;

    public AudioClip flipClip, pointClip, diedClip;

    public int score=0;

    private void Awake()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
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
               // audioSource.clip = flipClip; // alternetiv is playoneshot
                audioSource.PlayOneShot(flipClip);
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.LogError("-------collision------"+col.gameObject.name);

        if(col.gameObject.tag=="Ground" || col.gameObject.tag=="Pipe")
        {
            if(isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Die");
                audioSource.PlayOneShot(diedClip);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.LogError("--------Collider----------"+col.gameObject.name);
        if(col.tag=="PipeHolder")
        {
            score++;
            audioSource.PlayOneShot(pointClip);
        }
    }


}
