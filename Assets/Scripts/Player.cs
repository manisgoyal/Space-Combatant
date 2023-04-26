using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 5f;


    private float movX;
    private float movY;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;
    
    private Animator anim;
    private bool onGround = false;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
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
        jumpPlayer();
        
    }


    //private void FixedUpdate()
    //{
    //  jumpPlayer();
    //}
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
        if(movX > 0f)
        {
            // going right
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }else if(movX < 0f) {
            // going left
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            myBody.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            onGround = true;
        }
    }
}
