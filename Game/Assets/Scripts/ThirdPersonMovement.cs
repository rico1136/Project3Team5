using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public float speed = 6f;

    public Vector3 direction;
    public float gravity = 20.0F;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Animator animator;
    public CountDownTimer countDownTimer;
    public GameObject introText;
    private Rigidbody rb;
    public bool canWalk = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private bool hasWalked = false;

    // Update is called once per frame
    void Update()
    {
        

        if (canWalk)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            animator.SetFloat("Speed", direction.magnitude);
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            direction.y -= gravity * Time.deltaTime;
            rb.velocity = direction * speed;
            if (!hasWalked)
            {
                if (horizontal != 0 && vertical != 0)
                {
                    countDownTimer.gameObject.SetActive(true);
                    countDownTimer.hasWalked = true;
                    hasWalked = true;
                    introText.SetActive(false);
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetFloat("Speed", 0);
        }
    }
}
