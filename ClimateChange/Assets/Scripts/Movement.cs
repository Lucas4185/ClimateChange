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

    private GameObject ScoreText;

    private bool timeBool = false;

    private bool moveBack = false;

    private float moveDown = 1f;

    private float moveUp = 30f;

    private ScoreUI scoreUI;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        sun = GameObject.Find("Sun");

        ScoreText = GameObject.Find("ScoreText");

        if (gameObject.tag == "Leftcloud")
        {
            oldPos = transform.position;
        }
        else if (gameObject.tag == "Rightcloud")
        {
            oldPos = transform.position;
        }

        scoreUI = ScoreText.gameObject.GetComponent<ScoreUI>();

    }

    private void Update()
    {
        moveDown += 0.1f * Time.deltaTime;

        if (gameObject.tag == "Leftcloud")
        {
            Move(-10, 0);
        }
        else if (gameObject.tag == "Rightcloud")
        {
            Move(10, 0);
        }
        OnPress();
        if (gameObject.tag == "Bear")
        {
            Move(0, -moveDown);
        }


        timer -= Time.deltaTime;
        if(timeBool == true)
        {
            timer = 0.5f;
            timeBool = false;
        }

        PowerUp();
    }

    private void Move(float xAmount, float yAmount)
    {
        rb.AddForce(new Vector2(xAmount, yAmount), ForceMode2D.Impulse);
    }

    private void OnPress()
    {

        if (Input.GetMouseButtonDown(0))
        {
            moveBack = false;
            timeBool = true;
            if (gameObject.tag == "Bear")
            {

                Move(0, moveUp);
            }

            else if (gameObject.tag == "Leftcloud")
            {
                if (timer > 0)
                {
                    Move(150, 0);

                }
            }
            else if (gameObject.tag == "Rightcloud")
            {
                if (timer > 0)
                {
                    Move(-150, 0);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveBack = true;
        }
    }

    private void PowerUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && scoreUI.IntScore >= 30)
        {
            moveUp += 10;
            scoreUI.IntScore -= 30;
        }
    }
}
