using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : MonoBehaviour {

    [SerializeField]private Joystick moveJoystick;
    [SerializeField]private float speed;
    private Vector3 curentRotation;

    private void Awake()
    {
        curentRotation = Vector3.zero;
    }

    private void Update()
    {
        if (moveJoystick.InputDirection != Vector3.zero)
        {
            //Debug.Log(moveJoystick.InputDirection + " input");
            if (moveJoystick.InputDirection.x < 0)
            {
                
                curentRotation.z += (moveJoystick.InputDirection.x * speed);
                if (curentRotation.z < -30)
                {
                    curentRotation.z = -30;
                }

                Quaternion quaternion = Quaternion.Euler(curentRotation);
                gameObject.transform.rotation = quaternion;
            }
            else if (moveJoystick.InputDirection.x > 0)
            {
                curentRotation.z -= (moveJoystick.InputDirection.x * -speed);
                if (curentRotation.z > 45)
                {
                    curentRotation.z = 45;
                }
                Quaternion quaternion = Quaternion.Euler(curentRotation);
                gameObject.transform.rotation = quaternion;
            }
        }
    }
}
