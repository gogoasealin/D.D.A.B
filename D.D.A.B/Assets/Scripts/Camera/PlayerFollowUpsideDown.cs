using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowUpsideDown : MonoBehaviour {

    private Transform target;

    private GameObject player;
    private Quaternion rotation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        rotation = Quaternion.Euler(0, 0, 180);
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 position = player.transform.position;
            position.z = -1f;
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}
