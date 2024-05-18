using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    private Transform target;


    NavMeshAgent agent;
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    private void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }


    // Update is called once per frame
    void Update() {
        agent.SetDestination(target.position);
    }
}
