using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5;

    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public HealthBar healthBar;
    public HungerBar hungerBar;
    
    public float maxHealth = 100f;
    public float currentHealth;
    public float hunger;
    public float maxHunger = 100f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        hunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
    }

    void Update()
    {
        //HEALTH/DAMAGE currently takes damage when space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);
        }

        //HUNGER BAR
        if (hunger >= 0)
        {
            hunger -= 2f * Time.deltaTime;
            hungerBar.SetHunger(hunger);
        }
        else if (hunger <= 0)
        {
            currentHealth -= 1f * Time.deltaTime;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

        animator.SetFloat("Speed",movement.sqrMagnitude);


        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } 
        
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void OnFire(){
        animator.SetTrigger("meleeAttack");
    }

    




    /*    
        public void changeHealth(int val){
            health += val;
            if(health < 1){
                Debug.Log("Player Died");
                Destroy(this.gameObject);
            }
        }
    */
}
