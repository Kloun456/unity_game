using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1Controller : MonoBehaviour
{
    public float speed;
    public bool isVertical;
    public float changeTimeDirection;
    public float timeAtack;
    public int LookX;
    public int LookY;
    public GameObject bullet;
    public Transform shotPoint;
    public int direction;

    private Rigidbody2D rigidBody;

    private float timerDirection;
    private float timerAtack;

    private Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        timerDirection = changeTimeDirection;
        timerAtack = timeAtack;
        animator.SetFloat("Look X", LookX);
        animator.SetFloat("Look Y", LookY);
    }   

    void FixedUpdate()
    {
        Vector2 position = rigidBody.position;
        
        timerDirection -= Time.deltaTime;
        timerAtack -= Time.deltaTime;
        if (timerDirection < 0)
        {
            timerDirection = changeTimeDirection;
            direction *= -1;
        }
        if (timerAtack < 0) 
        {
            timerAtack = timeAtack;
            animator.SetBool("Is Atack", true);
            Instantiate(bullet, shotPoint.position, transform.rotation);
        }

        if (isVertical)
        {
            position.y += speed * Time.deltaTime * direction;
        }
        else
        {
            position.x += speed * Time.deltaTime * direction;
        }

        rigidBody.MovePosition(position);
    }

    public void CancelAtack()
    {
        animator.SetBool("Is Atack", false);
    }
}
