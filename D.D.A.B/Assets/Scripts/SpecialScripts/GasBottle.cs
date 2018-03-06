using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBottle : MonoBehaviour {

    [SerializeField] private GameObject explosion;
    [SerializeField] private AnimationClip woodAnimation;  
    [SerializeField] private GameObject woodWall;
    [SerializeField] private GameObject Platforms;
    [SerializeField] private GameObject atlasFlame;
    [SerializeField] private Transform atlastFlameSpawnPosition;
    private Animator anim;
    private int count; 

    private void Awake()
    {
        anim = woodWall.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "BurningShuriken")
        {
            count++;
            if(count % 2 == 0)
            {
                Destroy(other.gameObject);
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(Burn());
            }

        }
    }


    private IEnumerator Burn()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("Fire", true);
        GameObject flames = Instantiate(atlasFlame, atlastFlameSpawnPosition.position, Quaternion.identity) as GameObject;
        float animationTime = woodAnimation.length * 5f;
        yield return new WaitForSeconds(animationTime);
        Platforms.SetActive(true);
        Destroy(flames.gameObject);
        Destroy(woodWall);
        Destroy(gameObject);
    }


}
