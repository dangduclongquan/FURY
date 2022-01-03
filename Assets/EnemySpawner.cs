using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0 && GameObject.FindGameObjectsWithTag("AI").Length<100)
        {
            Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
            timer = spawnDelay;
        }
    }
}
