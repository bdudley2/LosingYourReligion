using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;

    private float x, y;
    private bool isWalking;

    public float moveSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            isWalking = true;
            anim.SetBool("isWalking", isWalking);

            Move();
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isWalking", isWalking);
            }
        }
    }

    private void Move()
    {
        anim.SetFloat("X", x);
        anim.SetFloat("Y", y);

        transform.Translate(x * Time.deltaTime * moveSpeed, y * Time.deltaTime * moveSpeed, 0);
    }
}
