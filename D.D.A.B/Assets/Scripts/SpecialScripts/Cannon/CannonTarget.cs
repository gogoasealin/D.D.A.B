using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTarget : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotPosition;
    private void Update()
    {
        Spam();
    }

    private void Spam()
    {
        GameObject trajectory = Instantiate(shot, shotPosition.position, Quaternion.identity) as GameObject;
        trajectory.GetComponent<Rigidbody2D>().AddForce((transform.up + transform.right) * 200f);
    }
}
