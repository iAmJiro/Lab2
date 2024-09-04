using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Transform enemyTransform;


    public PlayerController player;
    public Transform target;
    [SerializeField]
    private int currentPosition = 0;

    public List<Transform> positions = new List<Transform>();
    void Start()
    {

        enemyAgent = GetComponent<NavMeshAgent>();
        enemyTransform = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerController>(); //How to reference a different script
    }

    void Update()
    {
        //Debug.Log(Vector3.Distance(player.transform.position, enemyTransform.transform.position).ToString());
        //Debug.Log(positions[0]);
        //Debug.Log(positions[1]);
        int enemyPositionX = (int)enemyAgent.transform.position.x;
        int enemyPositionZ = (int)enemyAgent.transform.position.z;
        int position1X = (int)positions[0].transform.position.x; //position[0]
        int position1Z = (int)positions[0].transform.position.z; //position[0]
        int position2X = (int)positions[1].transform.position.x; //position[1]
        int position2Z = (int)positions[1].transform.position.z; //position[1]

        Debug.Log(enemyPositionX);
        Debug.Log(enemyPositionZ);
        Debug.Log(position1X);
        Debug.Log(position1Z);
        if (Vector3.Distance(player.transform.position, enemyAgent.transform.position) <= 10) 
        {
           enemyAgent.destination = target.position;
        }
        if (Vector3.Distance(player.transform.position, enemyAgent.transform.position) > 10) 
        {
            enemyAgent.destination = positions[currentPosition].transform.position;
            Debug.LogWarning(enemyAgent.remainingDistance.ToString());
            if(!enemyAgent.pathPending && enemyAgent.remainingDistance < 0.6f)
            {
                currentPosition++;
                if(currentPosition > positions.Count - 1)
                {
                    currentPosition = 0;
                }
            }
            //enemyAgent.destination = positions[0].transform.position;
            //if (enemyPositionX == position1X && enemyPositionZ == position1Z)
            //{
            //    enemyAgent.destination = positions[1].transform.position;
            //}
            //else if (enemyPositionX == position2X && enemyPositionZ == position2Z) 
            //{
            //    enemyAgent.destination = positions[0].transform.position;
            //}
            
        }
    }
}
