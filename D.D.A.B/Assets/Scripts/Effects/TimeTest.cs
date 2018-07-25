using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class TimeTest : MonoBehaviour
{
    public float speedx;

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 4f;
    private float timer;
    private PlayerController playerControllerScript;
    private Animator anim;
    private void Awake()
    {
        playerControllerScript = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Time.timeScale += ((1f / slowdownLength) * Time.unscaledDeltaTime);
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Time.timeScale * .02f;

        if (playerControllerScript.speed > 1.2f)
        {
            playerControllerScript.speed -= 0.075f * Time.unscaledDeltaTime * 5;
            Debug.Log(playerControllerScript.speed + " speeddddddddddddddddddddddd " + Time.unscaledDeltaTime);
        }
        Debug.Log(Time.timeScale);
        //if (playerControllerScript.jumpForce > 4f)
        //{
        //    playerControllerScript.jumpForce -= 1.75f;
        //}
        //if (playerControllerScript.jumpDistance > 10f)
        //{
        //    playerControllerScript.jumpDistance -= 11.875f;
        //}
        //if (GetComponent<Rigidbody2D>().gravityScale > 1f)
        //{
        //    GetComponent<Rigidbody2D>().gravityScale -= 0.0625f;
        //}
        if (Time.timeScale == 1)
        {
            //Debug.Log(playerControllerScript.speed + " speed times uppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp");
            //Vector3 newVelocity = new Vector3(0, GetComponent<Rigidbody2D>().velocity.y, 0);
            //GetComponent<Rigidbody2D>().velocity = newVelocity;
            //playerControllerScript.speed = 1.2f;
            //playerControllerScript.jumpForce = 4f;
            //playerControllerScript.jumpDistance = 10f;
            //GetComponent<Rigidbody2D>().gravityScale = 1f;
            anim.updateMode = AnimatorUpdateMode.Normal;
            //Debug.Log(playerControllerScript.jumpForce + " jf");
            //Debug.Log(playerControllerScript.jumpDistance + " jd");
            //Debug.Log(GetComponent<Rigidbody2D>().gravityScale + " gs");
            //Debug.Log(timer + " timer");
        }
        if (CrossPlatformInputManager.GetButtonDown("Use") && timer > 2f || Input.GetKey(KeyCode.W) && timer > 2f)
        {
            DoSlowMotion();
            timer = 0f;
        }

    }

    public void DoSlowMotion()
    {

        Time.timeScale = slowdownFactor;
        playerControllerScript.speed = 2.4f;

        //playerControllerScript.jumpForce *= 8f;
        //playerControllerScript.jumpDistance *= 20f;
        //GetComponent<Rigidbody2D>().gravityScale *= 2f;
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;

    }
}
