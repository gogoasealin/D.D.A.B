using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteFollowPlayer : MonoBehaviour {

    private GameObject player;
    private Vector3 toAddPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        toAddPosition = new Vector3(0f, 0.2f, 0f);
    }

    void Update () {
        transform.position = player.transform.position + toAddPosition;
	}
}
