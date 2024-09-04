using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Weapon : MonoBehaviour
{
    public PlayerController player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>(); //How to reference a different script
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("HIT");
        }
    }
}
