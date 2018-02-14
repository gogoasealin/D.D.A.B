using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public GameObject[] objects;
    private float timer;
    private bool lighting;

	void Update () {
        timer += Time.deltaTime;

        if(timer >= 3f && lighting)
        {
            for(int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            timer = 0;
            lighting = false;
        }
        else if (timer >= 1.5f && !lighting)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            timer = 0;
            lighting = true;
        }
		
	}
}
