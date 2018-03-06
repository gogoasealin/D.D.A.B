using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CannonScript : MonoBehaviour {

    private GameObject player;
    private PlayerController playerController;
    [SerializeField]private bool shoting;
    [SerializeField] private bool canShot;
    //[SerializeField] private float timeActive;
    private GameObject mainCamera;
    private Camera mainCameraScript;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCameraScript = mainCamera.GetComponent<Camera>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canShot = true;
        }  
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canShot = false;
        }
    }

    private void Update()
    {
        if(canShot && CrossPlatformInputManager.GetButtonDown("Use") || canShot && Input.GetKey(KeyCode.W))
        {
            if (!shoting)
            {
                shoting = true;
                playerController.enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                gameObject.GetComponent<CannonMove>().enabled = true;
                gameObject.GetComponent<CannonShotScript>().enabled = true;
                gameObject.GetComponent<CannonTarget>().enabled = true;
                mainCameraScript.orthographicSize = 2f;
            }
            else if(shoting)
            {
                shoting = false;
                gameObject.GetComponent<CannonMove>().enabled = false;
                gameObject.GetComponent<CannonShotScript>().enabled = false;
                gameObject.GetComponent<CannonTarget>().enabled = false;
                playerController.enabled = true;
                mainCameraScript.orthographicSize = 1.2f;
            }
        }
    }
}
