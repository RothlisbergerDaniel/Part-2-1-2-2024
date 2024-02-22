using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballGuy : MonoBehaviour
{

    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        selected(true);
    }

    public void selected(bool select)
    {
        if(select)
        {
            renderer.color = Color.red;
        }
        else
        {
            renderer.color = new Color(180, 0, 0, 255);
        }
    }
}
