using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject enemy;
    public GameObject dangerEnemy;
    private float count = 15;
    void Start()
    {
        InvokeRepeating("Enemy", 1f, 1f);
    }
    public void Enemy()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(4.6f, 0.34f), 0.459f, -20.01f), Quaternion.identity);
        }
    }
}
