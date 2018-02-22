using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float speed;
    private float dirX;
    private float dirY;
    private Rigidbody2D rb2d;
    public bool canJump;
    private GameObject gameController;
    private GameController gameControllerScript;
    public Joystick moveJoystick;
    private bool faceRight;
    public bool pause;
    public bool resume;
    private Quaternion movingLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion movingRight = Quaternion.Euler(0, 0, 0);
    private float verticalVelocity;
    public float jumpForce ;
    public float jumpDistance;
    private bool playerOnJoystickPosition;
    public bool facingRight;
    public GameObject trowPosition;
    public GameObject trowPrefab;
    public bool canUseShuriken;
    private Animator anim;


    void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        facingRight = true;
        anim = GetComponent<Animator>();
    }


    void Update() {



        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dirX = moveJoystick.InputDirection.x * speed;
            if (dirX < 0)
            {
                gameObject.transform.rotation = movingLeft;
                facingRight = false;
            }
            else
            {
                gameObject.transform.rotation = movingRight;
                facingRight = true;
            }
            anim.SetBool("Moving", true);
        }
        else
        {
            dirX = 0;
            anim.SetBool("Moving", false);
        }

        if (dirX == 0)
        {
            dirX = Input.GetAxis("Horizontal");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            DoJump();
        }
        if (canUseShuriken)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TrowShuriken();
            }
            if (CrossPlatformInputManager.GetButtonDown("Down"))
            {
                TrowShuriken();
            }

        } 
        //CheckPlayerPosition();
        //JoystickInvisible();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameControllerScript.SwitchPause();         
        }
        if (pause)
        {
            gameControllerScript.Pause();
        }
        else if (!pause)
        {
            if (resume)
            {
                gameControllerScript.ResumeButton();
            }
        }
    }

    public void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX * speed, rb2d.velocity.y);
    }

    public void DoJump()
    {
        if (canJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + jumpDistance, jumpForce);
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
        if(other.gameObject.tag == "Enemy")
        {
            gameControllerScript.GameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    //private void CheckPlayerPosition()
    //{
    //    Vector3 tmpPos = Camera.main.WorldToScreenPoint(transform.position);
    //    if (tmpPos.x < (Screen.width / 3) && tmpPos.y < (Screen.height / 3))
    //    {
    //        playerOnJoystickPosition = true;
    //    }
    //    else playerOnJoystickPosition = false;
    //    //Debug.Log(tmpPos.x + " " + (Screen.width / 3) + " " + tmpPos.y + " " + (Screen.height / 3));
    //}

    //private void JoystickInvisible()
    //{
    //    if (playerOnJoystickPosition)
    //    {
    //        Color tempColor = new Color(1f, 1f, 1f, 0.1765f);
    //        moveJoystick.bgImg.color = tempColor;
    //        moveJoystick.joystickImg.color = tempColor;
    //    }
    //    else
    //    {
    //        moveJoystick.bgImg.color = new Color(255, 255, 255, 255);
    //        moveJoystick.joystickImg.color = new Color(255, 255, 255, 255);
    //    }
    //}

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        gameControllerScript.GameOver();
    }

    private void TrowShuriken()
    {
        Instantiate(trowPrefab, trowPosition.transform.position, Quaternion.identity);
    }
}
