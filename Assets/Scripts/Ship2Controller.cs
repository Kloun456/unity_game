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
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public float shotForce;

    private Rigidbody2D rigidBody;
    private float timerAtack;
    private Animator animator;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
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
            GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
            Bullet bulletController = bulletObject.GetComponent<Bullet>();
            bulletController.Launch(new Vector2(LookX, LookY), shotForce);
        }

        rigidBody.MovePosition(position);
    }

    public void CancelAtack()
    {
        animator.SetBool("Is Atack", false);
    }
}
