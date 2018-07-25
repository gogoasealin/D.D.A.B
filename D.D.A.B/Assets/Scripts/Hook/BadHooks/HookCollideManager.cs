using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollideManager : MonoBehaviour {

    [SerializeField] private GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (ContactPoint2D contact in other.contacts)
        {
            if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player")
            {
                player.GetComponent<HookWithAnimation>().hit = true;
                player.GetComponent<HookWithAnimation>().hookContact = contact.point;
                Debug.Log(player.GetComponent<HookWithAnimation>().hookContact);
                GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        //if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player")
        //{
        //    player.GetComponent<HookWithAnimation>().hit = true;
        //    player.GetComponent<HookWithAnimation>().hookContact = other.gameObject.transform.position;
        //    Debug.Log(player.GetComponent<HookWithAnimation>().hookContact);
        //    GetComponent<BoxCollider2D>().isTrigger = true;
        //}
        Debug.Log("si");
    }

}
