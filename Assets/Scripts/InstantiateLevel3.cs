using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel3 : MonoBehaviour
{
    public GameObject enemy;
    private float count = 15;
    public GameObject dangerEnemy;
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
        for (int i = 0; i < 4; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(-12.69f, -13.28f), 0.459f, Random.Range(11.21f, 10.67f)), Quaternion.AngleAxis(132, Vector3.up));
        }
        for (int i = 0; i < 3; i++)
        {
            Instantiate(dangerEnemy, new Vector3(18.954f, 0.459f, Random.Range(-3.538f, -0.94f)), Quaternion.AngleAxis(-90, Vector3.up));
        }
    }
}
