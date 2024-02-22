using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballGuy : MonoBehaviour
{

    SpriteRenderer renderer;
    public Color selectColor;
    Rigidbody2D rb;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        selected(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
        Debug.Log("Clicked");
    }

    public void selected(bool select)
    {
        if(select == true)
        {
            renderer.color = Color.red;
        }
        else
        {
            renderer.color = selectColor;
        }
    }

    public void move(Vector2 dir)
    {
        rb.AddForce(dir * speed);
    }
}
