using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rb;
    private Vector2 movement;

    public int health = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }

    public void changeHealth(int val){
        health += val;
        if(health < 1){
            Debug.Log("Player Died");
            Destroy(this.gameObject);
        }
    }
}
