using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformShuriken : MonoBehaviour {

    [SerializeField]private GameObject burningShuriken;
    private BurningShuriken burningShurikenScript;
    private int count;

    private void OnTriggerExit2D(Collider2D other)
    {
        count++;
        if (other.tag == "Shuriken" && (burningShuriken != null) && (count % 2 == 0))
        {
            Vector3 shurikenPosition = other.gameObject.transform.position;
            Vector3 flamePosition = gameObject.transform.position;
            if(flamePosition.x < shurikenPosition.x){
                Vector3 nextPosition = other.transform.position;
                nextPosition += new Vector3(0.27f, 0f, 0f);
                Destroy(other.gameObject);
                GameObject shuriken = Instantiate(burningShuriken, nextPosition, Quaternion.identity) as GameObject;
                shuriken.GetComponent<BurningShuriken>().left = false;

            }
            else
            {
                Vector3 nextPosition = other.transform.position;
                nextPosition -= new Vector3(0.27f, 0f, 0f);
                Destroy(other.gameObject);
                GameObject shuriken = Instantiate(burningShuriken, nextPosition, Quaternion.identity) as GameObject;
                shuriken.GetComponent<BurningShuriken>().left = true;
            }

        }
    }
}
