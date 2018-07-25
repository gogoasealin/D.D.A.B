using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonOnlyShooting : MonoBehaviour {

    [SerializeField] float timeBetweenShots;
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotPosition;
    private Quaternion rotation;


    private void Start()
    {
        StartCoroutine(Shoting());
    }

    IEnumerator Shoting()
    {
        while (true)
        {
            Instantiate(shot, shotPosition.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(timeBetweenShots);
        }

    }
}
