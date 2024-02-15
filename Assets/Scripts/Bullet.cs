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

    void Start()
    {
        timerLife = lifeTime;
    }

    void Update()
    {
        timerLife -= Time.deltaTime;
        if (timerLife < 0)
        {
            timerLife = lifeTime;
            Destroy(gameObject);
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsPlayer);
        if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player")) 
        {
            hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
