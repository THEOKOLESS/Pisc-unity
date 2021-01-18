using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask testMask;
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    private Vector3 right;
    private Vector3 left;
    private Vector3 up;
    private float speed;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    private Collider2D collider2d;
    private float currentHeight;
    void Start()
    { 
        right = new Vector3(1, 0, 0);
        left = new Vector3(-1, 0, 0);
        up = new Vector3(0, 1, 0);
        speed = 3f;
        Physics2D.gravity = new Vector2(0, -2);
    }

    // Update is called once per frame
    void Update()
    {
   
       rigidbody2d = red.transform.GetComponent<Rigidbody2D>();
     
        if (Input.GetKey("right"))
        {
            red.transform.Translate(right * Time.deltaTime * speed);
        }

        if (Input.GetKey("left"))
        {
            red.transform.Translate(left * Time.deltaTime * speed);
        }
    
        if ((rigidbody2d.velocity.y == 0 ) && Input.GetKeyDown("space"))
        {
            rigidbody2d.velocity = up * speed;
        }
       

    }

    private void OnTriggerEnter2d(Collider2D other)
    {
        Debug.Log(other.tag);
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(red.GetComponent<Collision2D>());
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            Debug.Log("bpw");
        }
        else if (collision.collider.GetType() == typeof(CircleCollider2D))
        {
            Debug.Log("circle");
            // do stuff only for the circle collider
        }
    }



    
}

    
