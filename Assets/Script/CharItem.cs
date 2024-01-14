using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharItem : MonoBehaviour
{
    private Vector3 vector3;
    private Rigidbody2D rb;
    public float fallSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        vector3 = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MushRoom")) {
            
            Die();
        }
        Debug.Log(collision.gameObject.tag); // log ra xem char va chạm vào cái gì

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
        } 
    }
    public void ResetPlayer()
    {
        
        transform.position = vector3;
    }

    void Die()
    {
        
        float RSDelay = 2f;
        Invoke("ResetPlayer", RSDelay);
        rb.velocity = new Vector2(0, -fallSpeed);
    }
}
