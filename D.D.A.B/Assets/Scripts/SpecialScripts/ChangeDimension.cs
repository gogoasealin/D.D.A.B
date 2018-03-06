using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ChangeDimension : MonoBehaviour {

    private bool startDimension;
    [SerializeField] private GameObject[] dimension1;
    [SerializeField] private GameObject[] dimension2;

    private void Awake()
    {
        startDimension = true;
    }

    void Update () {
		if(CrossPlatformInputManager.GetButtonDown("Use"))
        {
            ChangeTheDimension();
        }
	}

    void ChangeTheDimension()
    {
        if (startDimension)
        {
            for(int i = 0; i < dimension1.Length; i++)
            {
                dimension1[i].SetActive(false);
            }

            for(int i = 0; i < dimension2.Length; i++)
            {
                dimension2[i].SetActive(true);
            }
            startDimension = false;
        }
        else
        {
            for (int i = 0; i < dimension1.Length; i++)
            {
                dimension2[i].SetActive(false);
            }

            for (int i = 0; i < dimension2.Length; i++)
            {
                dimension1[i].SetActive(true);
            }
            startDimension = true;
        }
    }

}
