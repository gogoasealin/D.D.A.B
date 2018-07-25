using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class HookWithAnimation : MonoBehaviour {

    [SerializeField] private GameObject hook;
    float MaxDistance = 0.3f;
    private bool go;
    public Joystick moveJoystick;
    private Vector3 initialScale;
    private Vector3 growingDirection;
    public bool hit;
    private bool canHook;
    public Vector3 hookContact;
    private Vector3 hookStart;
    private bool stopGrowing;
    public bool hooking;
    public bool hookingSetup;
    private Animator hookAnim;
    [SerializeField] private AnimationClip growAnimation;
    [SerializeField] private AnimationClip hitAnimation;
    private bool onceGrow;
    private bool onceDecrease;
    private float hookGrowTimer;
    private float hookDecreaseTimer;
    [SerializeField]private float hookMovementSpeed;
    private float HookColdown;
    private Vector3 hookNextPosition;
    private float animationTimerPass;

    private void Awake()
    {
        hook.SetActive(false);
        initialScale = hook.transform.localScale;
        canHook = true;
        hookAnim = hook.GetComponent<Animator>();
    }

    private void Update()
    {
        if ((CrossPlatformInputManager.GetButtonDown("Down") || Input.GetKeyUp(KeyCode.Q)) && HookColdown > 2f && canHook)
        {
            hookingSetup = true;
            GetComponent<TimeManager>().DoSlowMotion();
            GetComponent<TimeManager>().timer = 0;
        }

        if (hookingSetup)
        {
            canHook = false;
            if (Mathf.Abs(moveJoystick.InputDirection.x) > 0 || Mathf.Abs(moveJoystick.InputDirection.y) > 0) /// take the direction where player is loking to hook there
            {
                growingDirection.x = moveJoystick.InputDirection.x;
                growingDirection.y = moveJoystick.InputDirection.z;
            }
            else
            {
                if (GetComponent<PlayerController>().facingRight) /// if player don't press on joystick we will hook where player is looking
                {
                    growingDirection.x = 1f;
                }
                else
                {
                    growingDirection.x = -1f;
                }
            }
            growingDirection.z = 0;
            hook.transform.rotation = Quaternion.Euler(0, 0, 0);
            hook.transform.position = transform.position;
            hookNextPosition = (hook.transform.position + (growingDirection * 100f));
            GetComponent<PlayerController>().canJump = true;
            hooking = true;
            hookingSetup = false;
            hook.SetActive(true);
            onceGrow = true;
            onceDecrease = true;
            hookStart = hook.transform.position;
            Vector3 moveDirection = growingDirection;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                hook.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            hookGrowTimer = 0;
            hookDecreaseTimer = 0;
        }

        if (hooking)
        {
            if (onceGrow) // setari facute la inceputul hookului
            {
                hookAnim.SetFloat("Multiplier", 1f);
                hookAnim.SetBool("grow", true);
                onceGrow = false;
                hook.SetActive(true);
                GetComponent<Rigidbody2D>().isKinematic = true;
            }
            if (!hit) // rularea animatie de hook
            {                        
                hook.transform.position = Vector2.MoveTowards(hook.transform.position, hookNextPosition, hookMovementSpeed * Time.deltaTime);
                hookGrowTimer += Time.deltaTime;
                if (hookGrowTimer > growAnimation.length)
                {
                    hookAnim.SetBool("grow", false);
                    StopGrowingAnimation();
                }
                animationTimerPass += Time.deltaTime;
            }
            else // daca loveste ceva 
            {
                if (onceDecrease)
                {
                    hookAnim.SetFloat("Multiplier", -1f); // rulam animatia de micsorare
                    onceDecrease = false;
                    hookDecreaseTimer = 0;
                    Debug.Log(growAnimation.length + " timpul animatiei");
                    Debug.Log(animationTimerPass + " animationTimerPass");
                    Debug.Log(growAnimation.length - animationTimerPass);
                }

                if (hookDecreaseTimer >= (animationTimerPass - 0.001f)) 
                {
                    hookAnim.SetBool("grow", false);
                    StopDecreaseAnimation();
                }
                hookDecreaseTimer += Time.deltaTime;
                hook.transform.position = Vector2.MoveTowards(hook.transform.position, hookContact, hookMovementSpeed * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, hookContact, hookMovementSpeed*10f * Time.deltaTime);
                Debug.Log(hookDecreaseTimer + " decreaser timer" );
            }

        }
        HookColdown += Time.deltaTime;
    }

    void StopGrowingAnimation()
    {
        hook.SetActive(false);
        hooking = false;
        hookGrowTimer = 0;
        canHook = true;
        hit = false;
        HookColdown = 0;
        animationTimerPass = 0;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void StopDecreaseAnimation()
    {
        hook.SetActive(false);
        hooking = false;
        hookDecreaseTimer = 0;
        animationTimerPass = 0;
        canHook = true;
        hit = false;
        HookColdown = 0;
        hook.GetComponentInChildren<BoxCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
