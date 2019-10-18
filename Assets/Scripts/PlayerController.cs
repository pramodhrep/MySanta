using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float moveSpeed;
    public Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckradius;
    public LayerMask groundLayer;
    private bool onGround;

    public float jumpSpeed = 8f;

    public float horizontalMove = 0f;
    public Animator animator;

    public bool died = false;
    public bool alive = true;
    public bool idle = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * 0.2f;

        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));

        movePlayer();

    }

    private void movePlayer()
    {
        if (died == false)
        {
            if(!Input.anyKey)
            {
                idle = true;
                animator.SetBool("Idle", idle);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                idle = false;
                animator.SetBool("Idle", idle);
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                flipPlayer();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                idle = false;
                animator.SetBool("Idle", idle);
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                flipPlayer();
            }
            else if (Input.GetKey(KeyCode.Space) && onGround)
            {
                idle = false;
                animator.SetBool("Idle", idle);
                animator.SetBool("Died", died);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }

        }
        else if(died == true && Input.GetKey(KeyCode.R))
        {
            died = false;
            alive = true;

            animator.SetBool("Alive", alive);

            animator.SetBool("Died", died);
            
        }
    }

    private void flipPlayer()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckradius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag.Equals("Bomb"))
        {
            died = true;
            animator.SetBool("Died", died);
            alive = false;
            animator.SetBool("Alive", alive);
            idle = false;
            animator.SetBool("Idle", idle);
        }
    }
}
