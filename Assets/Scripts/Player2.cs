using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;


    private float movX;
    private float movY;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        moveKeyBoard();
        animatePlayer();
    }

    private void moveKeyBoard()
    {
        movX = Input.GetAxisRaw("Horizontal");
        // 1 if (d or right arrow)
        // -1 if(a or left arrow)

        // movY = Input.GetAxisRaw("Vertical");
        transform.position += moveForce * Time.deltaTime * new Vector3(movX, 0f, 0f);

    }

    private void animatePlayer()
    {
        if (movX > 0f)
        {
            // going right
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movX < 0f)
        {
            // going left
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }
}
