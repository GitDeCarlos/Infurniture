using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyEntityController : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject playerObject;
    public float directionFacing;
    public float m_speed;
    public float AggroDistance;
    
    private Animator animator;
    private float distance;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        
        distance = Vector2.Distance(transform.position, playerObject.transform.position);
        Vector2 direction = playerObject.transform.position - transform.position;
        if(distance < AggroDistance){
            agent.SetDestination(playerObject.transform.position);
            //transform.position = Vector2.MoveTowards(this.transform.position, playerObject.transform.position, m_speed * Time.deltaTime);
            animator.SetFloat("velocity", 1);
            if (direction.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }else{
            //agent.Stop();
            animator.SetFloat("velocity", 0);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")//obj.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Damaged");
            playerObject.GetComponent<PlayerController>().takeDamage(30);
        }
    }
}
