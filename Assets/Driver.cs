using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    [SerializeField] float boostTimer = 0f;
    [SerializeField] float slowTimer = 0f;

    bool isBoosted;
    bool isSlowed;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (isBoosted)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                moveSpeed = 20f;
                boostTimer = 0f;
                isBoosted = false;
            }
        }

        if (isSlowed)
        {
            slowTimer += Time.deltaTime;
            if (slowTimer >= 2)
            {
                moveSpeed = 20f;
                slowTimer = 0f;
                isSlowed = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        Debug.Log("Slow Speed!"); 
        isSlowed = true;
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boosts")
        {
            Debug.Log("Boost Speed!");
            isBoosted = true;
            moveSpeed = boostSpeed;
        }
    }
}
