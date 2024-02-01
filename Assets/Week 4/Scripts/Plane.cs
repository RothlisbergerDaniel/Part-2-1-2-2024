using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{


    public List<Vector2> points;
    Vector3 lastPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    public float speed = 1;
    public AnimationCurve landing;
    float timerValue;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Color danger;
    public Color safe;
    

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        transform.Translate(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        transform.Rotate(0, 0, Random.Range(-180f, 180f));
        speed = Random.Range(1, 3);
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        spriteRenderer.color = safe;
        
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0) 
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    timerValue += 0.5f * Time.deltaTime;
        //    float interpolation = landing.Evaluate(timerValue);
        //    if(transform.localScale.z < 0.1)
        //    {
        //        Destroy(gameObject);
        //    }
        //    transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        //}
        lineRenderer.SetPosition(0, transform.position);
        if(points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < pointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //use a Vector2 to truncate the Z value
        if (Vector2.Distance(newPosition, lastPosition) > pointThreshold) {
            points.Add(newPosition);
            lastPosition = newPosition;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 3)
        {
            spriteRenderer.color = danger;
        }
        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject planeToCheck = collision.gameObject;
        
        if (Vector2.Distance(planeToCheck.transform.position, transform.position) < pointThreshold * 2 && planeToCheck.layer != 3)
        {
            Destroy(planeToCheck);
            Destroy(gameObject);
        }

        if(planeToCheck.layer == 3)
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);
            if (transform.localScale.z < 0.2)
            {
                Debug.Log("Score +1!");
                Destroy(gameObject);
                
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = safe;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
