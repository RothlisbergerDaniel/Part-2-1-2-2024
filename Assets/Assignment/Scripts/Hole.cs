using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    Rigidbody2D rb;
    public float health = 10;
    public GameObject ballPrefab;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Player>().collected) //check if collided with player and player has the ball collected
        {
            collision.gameObject.SendMessage("deposit");
            health -= 1;
            healthSlider.value = health;
            if(health > 0)
            {
                Instantiate(ballPrefab); //create new ball to collect if there is still hole health remaining
            }
            else
            {
                SceneManager.LoadScene(0); //load start scene if at zero hole health
            }
        }
    }
}
