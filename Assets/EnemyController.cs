using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject chosen = null;
        foreach(GameObject player in players)
        {
            if (chosen == null)
                chosen = player;
            if (Vector3.Distance(navMeshAgent.transform.position, player.transform.position) < Vector3.Distance(navMeshAgent.transform.position, chosen.transform.position))
                chosen = player;
        }
        navMeshAgent.SetDestination(chosen.transform.position);
    }
}
