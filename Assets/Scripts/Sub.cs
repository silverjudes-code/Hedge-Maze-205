using UnityEngine;

public class Sub : MonoBehaviour
{
    Rigidbody myRb; // Start is called once before the first execution of Update after the MonoBehaviour is created 
    public AudioClip metalClunk;
    public AudioClip waterAmbience;
    //public Transform target; (for Seak script)
    //angular vs linear damping - look up difference

    void Start()
    {
        myRb = GetComponent<Rigidbody>(); //()=function
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            myRb.AddForce(0f, 0f, 7f);
        }
        if (Input.GetKey("s"))
        {
            myRb.AddForce(0f, 0f, -7f);
        }
        if (Input.GetKey("a"))
        {
            myRb.AddForce(-7f, 0f, 0f);
        }
        if (Input.GetKey("d"))
        {
            myRb.AddForce(7f, 0f, 0f);
        }
        if (Input.GetKey("q"))
        {
            myRb.AddForce(0f, 20f, 0f);
        }
        if (Input.GetKey("e"))
        {
            myRb.AddForce(0f, -2f, 0f);
        }
        if (Input.GetKey("b"))
        {
            myRb.linearVelocity *= 0.8f;
        }
        Debug.Log(myRb.linearVelocity);

        //(make a Seek code separately and attach it in inspector to what you want to seek)
        //(play with proximity and force multiplier to get it right)
        //Vector3 targetOffset = targetOffset.position - transform.position;
        //Vector3 targetDirection = Vector3.Normalize(targetOffset);
        //myRb.AddForce(targetDirection * 50f);
    }

    void OnCollisionEnter(Collision colReport)
    //void = function, Collision = class
    //void returns nothing, OnCollisionEnter is the name of the function
    //this will be called when a collision occurs that is attached to this object
    {
        Debug.Log("That's coming out of your paycheck");
        GetComponent<AudioSource>().PlayOneShot(metalClunk, .95f);
    }

}