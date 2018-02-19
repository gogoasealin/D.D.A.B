using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private GameObject gameController;
    private GameController gameManagerScript;
    private Animator anim;
    public AnimationClip animDie;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameController.GetComponent<GameController>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManagerScript.GameOver();
        }

        if(other.gameObject.tag == "Shuriken")
        {
            Destroy(other.gameObject);
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("die", true);
        yield return new WaitForSeconds(animDie.length);
        Destroy(gameObject);
    }


}
