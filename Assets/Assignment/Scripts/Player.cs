using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 destination = Vector2.zero;
    Vector2 movement = Vector2.zero;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;

    bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.rotation = Mathf.Atan2(destination.x - rb.position.x, destination.y - rb.position.y) * Mathf.Rad2Deg * -1; //point towards mouse when clicked
        }
        animator.SetFloat("Movement", movement.magnitude);
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void collect()
    {
        collected = true;
        animator.SetTrigger("Pickup");
    }
}
