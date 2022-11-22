using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntityController : MonoBehaviour
{
    public GameObject playerObject;
    public float directionFacing;
    public float m_speed;
    public float AggroDistance;
    
    private Animator animator;
    private float distance;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
        distance = Vector2.Distance(transform.position, playerObject.transform.position);
        Vector2 direction = playerObject.transform.position - transform.position;
        if(direction.x > 0){
            GetComponent<SpriteRenderer>().flipX = true;
        }else{
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(distance < AggroDistance){
            transform.position = Vector2.MoveTowards(this.transform.position, playerObject.transform.position, m_speed * Time.deltaTime);
            animator.SetFloat("velocity", 1);
        }else{
            animator.SetFloat("velocity", 0);
        }
    }
}
