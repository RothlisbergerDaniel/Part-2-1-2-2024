using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    public Vector3 spawn = new Vector3(6, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawn = new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5), 0); //have to include UnityEngine for some reason, random spawn each time
        transform.position = spawn; //reset ball position
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") //check if collided with player
        {
            collision.gameObject.SendMessage("collect"); //tell the player to collect the ball
            Destroy(gameObject); //destroy the ball
        }
    }
}
