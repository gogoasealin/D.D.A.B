using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CannonShotScript : MonoBehaviour {

    [SerializeField] GameObject shot;
    [SerializeField] Transform shotPosition;
    private Quaternion rotation;
    [SerializeField] private int shots;
    private int count;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BurningShuriken")
        {
            count++;
            if (shots < 3 && (count % 2 == 0))
            {
                shots++;
            }
            Destroy(other.gameObject);
        }
    }

    void Update () {
		if(CrossPlatformInputManager.GetButtonDown("Down") && (shots > 0 ))
        {
            GetComponent<CannonTarget>().enabled = false;
            Shot();
            Invoke("StartTarget", 0.5f);
        }
	}

    void Shot()
    {
        DestroyAllShotDirection();
        rotation = gameObject.transform.rotation;
        GameObject shotInstance = Instantiate(shot, shotPosition.position, rotation);
        shotInstance.transform.parent = gameObject.transform;
        shots--;
    }

    void DestroyAllShotDirection()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("ShotDirection");
        for(int i = 0; i < targets.Length; i++)
        {
            Destroy(targets[i]);
        }
    }

    void StartTarget()
    {
        GetComponent<CannonTarget>().enabled = true;
    }
}
