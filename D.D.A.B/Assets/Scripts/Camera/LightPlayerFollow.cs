using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerFollow : MonoBehaviour {

    [SerializeField] private Transform target;

    void Update () {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -0.2f);
        }
    }
}
