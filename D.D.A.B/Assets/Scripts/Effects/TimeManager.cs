using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class TimeManager : MonoBehaviour {

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public float timer;
    private bool slowForHook;
    //private PlayerController playerControllerScript;
    private void Awake()
    {
        //playerControllerScript = GetComponent<PlayerController>();
        timer = 3f;
        if(GetComponent<HookWithAnimation>() != null)
        {
            slowForHook = true;
        }
        else
        {
            slowForHook = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!slowForHook)
        {
            timer += Time.deltaTime;
            Time.timeScale += (((1f / slowdownLength) * Time.unscaledDeltaTime) / 2);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Time.timeScale * .02f;
            //if(playerControllerScript.speed > 1.2f)
            //{
            //    playerControllerScript.speed -= (((1f / slowdownLength) * Time.unscaledDeltaTime) * 2f);
            //    Debug.Log(playerControllerScript.speed + "             " + Time.timeScale);
            //}
            //playerControllerScript.speed = Mathf.Clamp(playerControllerScript.speed, 1.2f, 24f);
            //if (Time.timeScale == 1f)
            //{
            //    //    Vector3 newVelocity = new Vector3(0, GetComponent<Rigidbody2D>().velocity.y, 0);
            //    //    GetComponent<Rigidbody2D>().velocity = newVelocity;
            //    //    playerControllerScript.speed = 1.2f;
            //    Debug.Log("gataaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + playerControllerScript.speed);
            //}
            if (CrossPlatformInputManager.GetButtonDown("Use") && timer > 2f || Input.GetKey(KeyCode.W) && timer > 2f)
            {
                DoSlowMotion();
                timer = 0f;
            }
        }else if(slowForHook){
            timer += Time.deltaTime;
            Time.timeScale += (((1f / slowdownLength) * Time.unscaledDeltaTime) / 2);
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Time.timeScale * .02f;

        }


	}

    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        //playerControllerScript.speed *= 4f;
    }
}
