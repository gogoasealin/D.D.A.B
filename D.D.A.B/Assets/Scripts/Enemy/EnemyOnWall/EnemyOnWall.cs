using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnWall : MonoBehaviour {

    private GameObject gameController;
    private GameController gameControllerScript;
    //private Animator anim;
    //public AnimationClip animDie;
    // private int getHit;
    [SerializeField] private float timeAfterAttack;
    [SerializeField] private int numberOfHitToDie;
    [SerializeField] private GameObject shot;
    //private bool dieStart;
    Coroutine ShotBullet;




    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        //anim = GetComponent<Animator>();
        ShotBullet = StartCoroutine(Shot()); ;
    }


    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        StopCoroutine(ShotBullet);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Shuriken")
    //    {
    //        getHit++;
    //        Destroy(other.gameObject);
    //        if (getHit == numberOfHitToDie)
    //        {
    //            if (!dieStart)
    //            {
    //                StartCoroutine(DieEnemyRange());
    //            }
    //        }
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameControllerScript.GameOver();
        }

    }

    //private IEnumerator DieEnemyRange()
    //{
    //    dieStart = true;
    //    gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //    anim.SetBool("die", true);
    //    yield return new WaitForSeconds(animDie.length);
    //    Destroy(gameObject);
    //}

    IEnumerator Shot()
    {
        while (true)
        {
            if (!gameControllerScript.death) //&& !dieStart)
            {
                Quaternion shotRotation = Quaternion.Euler(0, 0, 0);
                Instantiate(shot, gameObject.transform.position, shotRotation);
                shotRotation = Quaternion.Euler(0, 0, 45);
                Instantiate(shot, gameObject.transform.position, shotRotation);
                shotRotation = Quaternion.Euler(0, 0, 90);
                Instantiate(shot, gameObject.transform.position, shotRotation);
                yield return new WaitForSeconds(timeAfterAttack);
            }
            else
            {
                StopCoroutine(ShotBullet);
                break;
            }

        }
    }
}
