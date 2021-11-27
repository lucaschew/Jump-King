using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField] public float moveModifier = 3f;
    [SerializeField] public float maxJump = 400f;
    [SerializeField] public float minJump = 20f;
    [SerializeField] public float jumpModifier = 30f;
    [SerializeField] public LayerMask lm;
    [SerializeField] public float jumpMoveModifier = 20f;
    [SerializeField] public Joystick joystick;
    private Animator am;

    public bool jumpButton;
    private float jumpPower = 0, movement = 0;
    private bool direction = true;
    //true = right, false = left

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;


    // Start is called before the first frame update
    void Start()
    {

        jumpButton = false;

        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        am = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Power Release Jump

        //movement = Input.GetAxisRaw("Horizontal");

        try
        {

            movement = joystick.Horizontal;

        } catch (NullReferenceException e)
        {



        }

        //Debug.Log(jumpButton);

        if (jumpButton) //Input.GetButton("Jump") || 
        {

            jumpPower += (10f * Time.fixedDeltaTime);
            

        }

        if ((!jumpButton) && jumpPower > 0) //!Input.GetButton("Jump") || 
        {

            Move(0f, jumpPower, true);
            jumpPower = 0;
        }
        else
        {

            Move(movement, jumpPower, false);

        }

        if ((rb.velocity.x > 0 && !direction) || (rb.velocity.x < 0 && direction) && isGrounded())
        {
            Flip();
        }

        //Animator

        am.SetBool("touchingGround", isGrounded());
        am.SetFloat("Vertical Speed", rb.velocity.y);
        am.SetFloat("Horizontal Speed", Mathf.Abs(rb.velocity.x));

        if (jumpPower > 0)
        {
            am.SetBool("chargeJump", true);
        } else
        {
            am.SetBool("chargeJump", false);
        }



    }

    private void Move(float x, float y, bool jump) {

        if (jump && isGrounded())
        {
            rb.velocity = Vector3.zero;
            float dir = 0f;
            if (direction)
            {
                dir = jumpMoveModifier;
            }
            else
            {
                dir = -1 * jumpMoveModifier;
            }

            float x_vector = dir * moveModifier;

            if (Mathf.Min(Mathf.Max(minJump, jumpPower * jumpModifier), maxJump) < 250)
            {

                x_vector *= 2;

            }


            rb.AddForce(new Vector2(x_vector, Mathf.Min(Mathf.Max(minJump, jumpPower * jumpModifier), maxJump)));
            Debug.Log(Mathf.Min(Mathf.Max(minJump, jumpPower * jumpModifier), maxJump));

        } else if (isGrounded() && y == 0)
        {

            rb.velocity = new Vector2(x * moveModifier, rb.velocity.y);
            
        }

    }

    private bool isGrounded()
    {

        float extraHeightText = 0.05f;
        RaycastHit2D raycast = Physics2D.BoxCast(cc.bounds.center, new Vector2(cc.bounds.size.x - extraHeightText, cc.bounds.size.y), 0f, Vector2.down, extraHeightText, lm);
        Color rayColour;
        if (raycast.collider != null)
        {
            rayColour = Color.green;
        }
        else
        {
            rayColour = Color.red;
        }

        Debug.DrawRay(cc.bounds.center + new Vector3(cc.bounds.extents.x, 0), Vector2.down * (cc.bounds.extents.y + extraHeightText), rayColour);
        Debug.DrawRay(cc.bounds.center - new Vector3(cc.bounds.extents.x, 0), Vector2.down * (cc.bounds.extents.y + extraHeightText), rayColour);
        Debug.DrawRay(cc.bounds.center - new Vector3(0, cc.bounds.extents.y), Vector2.right * (cc.bounds.extents.x), rayColour);
        //Debug.Log(raycast.collider);

        return raycast.collider != null;

    }

    private void Flip()
    {

        direction = !direction;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void changeWorld(int a)
    {

        switch (a)
        {
            case 0:
                transform.position = new Vector3(0.3f, -1f, 0f);
                break;
            case 1:
                transform.position = new Vector3(0f, -3.5f, 0f);
                break;
            default:
                Debug.Log("World Does Not Exist");
                break;
                



        }


    }

    public void jumpButtonPressed()
    {

        jumpButton = true;


    }

    public void jumpButtonReleased()
    {

        jumpButton = false;


    }


}
