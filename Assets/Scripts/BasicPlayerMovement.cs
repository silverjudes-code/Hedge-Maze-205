using System;
using Unity.VisualScripting;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    //you can assign these in the inspector in unity
    public Transform hazard; 
    //public Transform wall; this is no good because its only 1 wall and there are many
    public Transform[] walls;
    public AudioSource ambiance;
    public AudioSource badTime; //click off Play on Awake in inspector then you can assign it 
    public AudioSource portal;
    public AudioSource golden;
    public AudioSource sleepyTime;
    public AudioSource sparkles;
    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //introduce a boolean variable to check if the player can move
        //go to chiptone to create 8 sound bits, then go under audio source/resource and assign it to the player - figure out how to make it not sound off immediately
            Vector3 newPos = new Vector3(0f, 0f, 0f);
            bool move = true;
        if (Input.GetKeyDown("w"))
            {
                newPos = transform.position + new Vector3(0f, 0f, 1f);
            }
        if (Input.GetKeyDown("s"))
            {
            newPos = transform.position + new Vector3(0f, 0f, -1f);
            }

        if (Input.GetKeyDown("a"))
            { 
            newPos = transform.position + new Vector3(-1f, 0f, 0f);
            }
        if (Input.GetKeyDown("d"))
            {
            newPos = transform.position + new Vector3(1f, 0f, 0f);
            }
        for (int i = 0; i < walls.Length; i++)
        {
            if (newPos == walls[i].position)
            {
                move = false;
            }
        }
        if (move && newPos != Vector3.zero)
        {
            transform.position = newPos;
        }
        if (transform.position == hazard.position)
        {
            //player.Play();
            transform.position = startPos;
        }
        //if (Input.GetKeyDown("q"))
        //{
        //transform.position += new Vector3(0f, -1f, 0f);
        //}
        //if (Input.GetKeyDown("e"))
        //{
        //transform.position += new Vector3(0f, 1f, 0f);
        //}
        //lowercase transform means it is a variable (meaning its local to what the code is being applied to, aka the player character), uppercase Transform means it is a class
        //vector = position, direction, or speed in 2D or 3D space - typically represented by x, y, and z coordinates
        //f at the end of += new Vector is to remind program it is a float not an integer
        //in play mode you can make changes to the landscape of the game, but when you stop playing it will revert back to the original state - good for testing
        //
        if (transform.position == new Vector3(1f, 1f, 11f))
        {
            print("you were cursed");
            badTime.Play();
            (transform.position) = startPos;
        }
        if (transform.position == new Vector3(12f, 1f, 11f))
        {
            print("you are rewarded");
            golden.Play();
            (transform.position) = new Vector3 (16f,1f,1f);
        }
        if (transform.position == new Vector3(17f, 1f, 2f))
        {
            print("the fairies laugh in the distance");
            sparkles.Play();
            (transform.position) = new Vector3(9f, 1f, 13f);
        }
        if (transform.position == new Vector3(5f, 1f, 3f))
        {
            print("you fell asleep");
            sleepyTime.Play();
            (transform.position) = startPos;
        }
        if (transform.position == new Vector3(8f, 1f, 12f))
        {
            print("you got lost in the woods");
            (transform.position) = startPos;
        }
        if (transform.position == new Vector3(9f, 1f, 12f))
        {
            print("you got lost in the woods");
            (transform.position) = startPos;
        }
        if (transform.position == new Vector3(10f, 1f, 12f))
        {
            print("you got lost in the woods");
            (transform.position) = startPos;
        }
        if (transform.position == new Vector3(9f,1f,16f))
        {
            portal.Play();
            print("the fairies welcome you... or do they?");
        }
    }
}