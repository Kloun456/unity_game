using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health;

    private float horizontal;
    private float vertical;

    private Rigidbody2D rigidBody;
    private Vector2 lookDirection;

    private Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lookDirection = new Vector2(0, 1);
    }


    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidBody.position;
        position.x += speed * Time.deltaTime * horizontal;
        position.y += speed * Time.deltaTime * vertical;
        
        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(0.0f, move.y))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        rigidBody.MovePosition(position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //Debug.Log(health);
    }

  

}
