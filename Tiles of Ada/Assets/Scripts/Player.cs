using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    //config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
  



    //state
    bool isAlive = true;

    //cache
    Animator myAnimator;
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider2D;
    float gravityScaleAtStart;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipPlayer();
        Jump();
        Die();
        Slide();

    }
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool playerHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;


        myAnimator.SetBool("Running", playerHorizontalSpeed);

    }

    private void Jump()
    {
        if (!myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
           
            Vector2 jumpVelocityAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityAdd;
         

        }


    }


    private void Die()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false; 
            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();

        }
    }



    private void FlipPlayer()
    {
        bool playerHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }



    private void Slide()
    {

        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ice")))
        {


                myRigidBody.AddForce(Vector2.right * 100);



            }

        }
    }
