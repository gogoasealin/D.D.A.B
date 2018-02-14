using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    [SerializeField] private float xMax;
    [SerializeField] private float yMax;
    [SerializeField] private float xMin;
    [SerializeField] private float yMin;
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
        }
    }

}
