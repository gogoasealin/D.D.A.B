using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Parachute : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool go;
    private bool once;
    private bool goUp;
    private GameObject parachuteObj;
    private Vector3 toAddPosition;
    [SerializeField] private float fallingSpeed;
    [SerializeField] private float risingSpeed;
    [SerializeField] private GameObject parachute;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        toAddPosition = new Vector3 (0f, 0.2f, 0f);
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Q) && !goUp)
        //{
        //    if (!once)
        //    {
        //        parachuteObj = Instantiate(parachute, transform.position + toAddPosition, Quaternion.identity) as GameObject;
        //        once = true;

        //    }
        //    rb2d.velocity = Vector3.down * fallingSpeed;

        //}
        //else if (Input.GetKey(KeyCode.Q) && goUp)
        //{
        //    if (!once)
        //    {
        //        parachuteObj = Instantiate(parachute, transform.position + toAddPosition, Quaternion.identity) as GameObject;
        //        once = true;

        //    }
        //    rb2d.velocity = Vector3.up * risingSpeed;
        //}
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    Destroy(parachuteObj.gameObject);
        //    once = false;
        //}
        ///////////////////////// V2
        if (CrossPlatformInputManager.GetButtonDown("Use"))
        {
            go = true;
        }

        if (go)
        {
            if (!once)
            {
                parachuteObj = Instantiate(parachute, transform.position + toAddPosition, Quaternion.identity) as GameObject;
                once = true;
            }
            if (Input.touchCount > 0 && !goUp)
            {
                rb2d.velocity = Vector3.down * fallingSpeed;
            }
            else if (Input.touchCount > 0 && goUp)
            {
                rb2d.velocity = Vector3.up * risingSpeed;
            }
            if (Input.touchCount == 0 || (Input.touchCount == 1 && (GetComponent<PlayerController>().dirX != 0 || GetComponent<PlayerController>().dirY != 0)))
            {
                Destroy(parachuteObj.gameObject);
                go = false;
                once = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fan")
        {
            goUp = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "fan")
        {
            goUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "fan")
        {
            StartCoroutine("StopRising");
        }
    }

    IEnumerator StopRising()
    {
        yield return new WaitForSeconds(1f);
        goUp = false;
    }
}
