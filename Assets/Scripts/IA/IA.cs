using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    public Transform nodo;
    void Start()
    {
        enemy.destination = nodo.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
