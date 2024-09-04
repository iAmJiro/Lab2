using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    public float cooldownTime = 5f; //the cooldown of how long the ability lasts before it ends
    public bool cooldownForSpeed;
    public float rotateSpeedMovement = 0.5f;
    float rotateVelocity;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) 
            {
                agent.speed = 5;
                agent.SetDestination(hit.point);
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));
                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }

        }
        if (Input.GetKey("q") && cooldownTime != 0) //DASH ABILITY
        {
            agent.speed = 50;
            agent.acceleration = 20;
            if (agent.speed == 50)
            {
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
            }
        }
    }
}
