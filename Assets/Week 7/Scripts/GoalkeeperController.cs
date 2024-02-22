using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public GameObject goalkeeper;
    Rigidbody2D rb;
    Vector2 direction;
    float dist;
    public float radius;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = goalkeeper.GetComponent<Rigidbody2D>(); //this is completely unnecessary
    }

    // Update is called once per frame
    void Update()
    {
        if(Controller.selectedPlayer == null)
        {
            direction = (Vector2)transform.position - Vector2.zero;
        }
        else
        {
            direction = (Vector2)transform.position - (Vector2)Controller.selectedPlayer.transform.position;
        }
        dist = direction.magnitude;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        if (dist / 2 < radius)
        {
            rb.position = Vector2.MoveTowards(rb.position, (Vector2)transform.position - direction * dist / 2, speed);
        }
        else
        {
            rb.position = Vector2.MoveTowards(rb.position, (Vector2)transform.position - direction * radius, speed);
        }
    }
}
