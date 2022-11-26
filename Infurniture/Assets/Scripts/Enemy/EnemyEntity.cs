using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public int health = 5;

    public void changeHealth(int val){
        health += val;
        if(health < 1){
            Debug.Log("Enemy Died");
            Destroy(this.gameObject);
        }
    }
}
