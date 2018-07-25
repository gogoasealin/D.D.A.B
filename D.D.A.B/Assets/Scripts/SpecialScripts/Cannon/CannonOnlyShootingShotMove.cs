using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonOnlyShootingShotMove : MonoBehaviour
{


    [SerializeField] private Vector3[] allPosition;
    [SerializeField] private float speed;
    private int nextPosition;

    private void Awake()
    {
        nextPosition = 1;
    }

    void Update()
    {
        GoToNextPosition();
    }

    void GoToNextPosition()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, allPosition[nextPosition], Time.deltaTime * speed);
        if (gameObject.transform.position == allPosition[nextPosition])
        {
            nextPosition++;
            if(nextPosition == allPosition.Length)
            {
                Destroy(gameObject);
            }
        }
        
    }

}

