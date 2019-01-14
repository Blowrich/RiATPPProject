using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Motor : MonoBehaviour {
    public float speed = 5f;
    public BoxCollider body;
    public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void Move(Vector3 point)
    {
        agent.destination = point;
    }
}
