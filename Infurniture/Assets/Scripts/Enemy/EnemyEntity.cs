using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyEntity : MonoBehaviour
{
    public int health = 5;
    public EnemyDropObj dropList;
    private Transform entityTransform;

    void Start(){
        entityTransform = GetComponent<Transform>();
        killEnemy(this.gameObject);
    }

    public void changeHealth(int val){
        health += val;
        if(health < 1){
            killEnemy(this.gameObject);
        }
    }

    public void killEnemy(GameObject enemyObject){
        Debug.Log("Enemy Died");
        Vector2 pos = new Vector2(entityTransform.position.x, entityTransform.position.y);
        Destroy(enemyObject);
        dropLoot(pos);
    }

    public void dropLoot(Vector2 position){
        System.Random rnd = new System.Random();
        for(int i = 0; i < dropList.objList.Count; i++){
            if(rnd.NextDouble() <= dropList.rates[i]){
                int dropCount = rnd.Next(dropList.amountMin[i], dropList.amountMax[i]);
                int index = dropList.itemDict.nameList.IndexOf(dropList.objList[i]);
                if(index != -1){
                    GameObject prefab = dropList.itemDict.prefabs[index];
                    for(int x = 0; x < dropCount; x++){
                        Vector2 offset = new Vector2((float) (2*(rnd.NextDouble()-0.5)), (float) (2*(rnd.NextDouble()-0.5)));
                        Instantiate(prefab, position+offset, Quaternion.identity);
                    }
                }
            }
        }
    }
}


