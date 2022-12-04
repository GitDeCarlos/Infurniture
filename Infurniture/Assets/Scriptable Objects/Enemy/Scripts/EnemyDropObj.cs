using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Drop Object", menuName = "Enemy/Drop")]
public class EnemyDropObj : ScriptableObject
{
    public ItemDictObj itemDict;
    public List<string> objList = new List<string>();
    public List<float> rates = new List<float>();
    public List<int> amountMin = new List<int>();
    public List<int> amountMax = new List<int>();
}
