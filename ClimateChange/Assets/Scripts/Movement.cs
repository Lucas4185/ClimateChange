using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float maxHeight = -0.8f;
    private float minHeight = -7.0f;

    private float timer = 0.5f;

    private Vector3 oldPos;
    
    private GameObject sun;

    private bool timeBool = false;

    private bool moveBack = false; 



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        sun = GameObject.Find("Sun");

        if (gameObject.tag == "Leftcloud")
        {
            oldPos = transform.position;
        }
        else if (gameObject.tag == "Rightcloud")
        {
            oldPos = transform.position;
        }

    }

    private void Update()
    {
        /*if (gameObject.tag == "Leftcloud")
        {
            transform.position = Vector3.MoveTowards(sun.transform.position, oldPos, 1 * Time.deltaTime);
        }
        else if (gameObject.tag == "Rightcloud")
        {
           transform.position = Vector3.MoveTowards(sun.transform.position, oldPos, 1 * Time.deltaTime);
        }*/
        OnPress();
        if (gameObject.tag == "Bear")
        {
            Move(0, -1);
        }

        if(moveBack == true)
        {
            if (gameObject.tag == "Leftcloud")
            {
                transform.position = Vector3.MoveTowards(sun.transform.position, oldPos, 1 * Time.deltaTime);
            }
           else if (gameObject.tag == "Rightcloud")
            {
                transform.position = Vector3.MoveTowards(sun.transform.position, oldPos, 1 * Time.deltaTime);
            }
        }

        timer -= Time.deltaTime;
        if(timeBool == true)
        {
            timer = 0.5f;
            timeBool = false;
        }
    }

    private void Move(float xAmount, float yAmount)
    {
        rb.velocity += new Vector2(xAmount, yAmount) * Time.deltaTime;
    }

    private void OnPress()
    {

        if (Input.GetMouseButtonDown(0))
        {
            moveBack = false;
            timeBool = true;
            if (gameObject.tag == "Bear")
            {

                Move(0, 50);
            }

            else if (gameObject.tag == "Leftcloud")
            {
                if (timer > 0)
                {
                    transform.position = Vector3.MoveTowards(oldPos, sun.transform.position, Time.deltaTime);

                }
            }
            else if (gameObject.tag == "Rightcloud")
            {
                if (timer > 0)
                {
                    transform.position = Vector3.MoveTowards(oldPos, sun.transform.position, Time.deltaTime);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveBack = true;
        }
    }
}
