using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2Controller : MonoBehaviour
{
    public float speed;
    public bool isVertical;
    public float timeAtack;
    public int LookX;
    public int LookY;
    public GameObject bullet;
    public Transform shotPoint;

    private Rigidbody2D rigidBody;

    private float timerAtack;

    private Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        timerAtack = timeAtack;
        animator.SetFloat("Look X", LookX);
        animator.SetFloat("Look Y", LookY);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidBody.position;

        timerAtack -= Time.deltaTime;
        if (timerAtack < 0)
        {
            timerAtack = timeAtack;
            animator.SetBool("Is Atack", true);
            Instantiate(bullet, shotPoint.position, transform.rotation);
        }

        rigidBody.MovePosition(position);
    }

    public void CancelAtack()
    {
        animator.SetBool("Is Atack", false);
    }
}
