using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnWallShot : MonoBehaviour {

    private Rigidbody2D rb2d;
    private GameObject gameController;
    private GameController gameManagerScript;
    [SerializeField] private float speed = 200;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameController.GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce((transform.up + transform.right) * speed);
        rb2d.angularVelocity = 200f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameManagerScript.GameOver();
        }
        else if(other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Shuriken")
        {
            Destroy(other.gameObject);
        }else if(other.tag == "Door")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
