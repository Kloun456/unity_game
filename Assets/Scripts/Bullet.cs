using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float distance;
    public float speed;
    public float lifeTime;
    public LayerMask whatIsPlayer;
    public int damage;

    private float timerLife;
    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        timerLife = lifeTime;
    }

    public void Launch (Vector2 direction, float force)
    {
        rigidBody.AddForce (direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
      
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }    
        
    }   

    void Update()
    {
        timerLife -= Time.deltaTime;
        if (timerLife < 0)
        {
            timerLife = lifeTime;
            Destroy(gameObject);
        }
        /*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsPlayer);
        if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player")) 
        {
            hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        transform.Translate(speed * Time.deltaTime * Vector2.up);*/
    }
}
