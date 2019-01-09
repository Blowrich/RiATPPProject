using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMotor : MonoBehaviour {

    public NavMeshAgent agent;

    public void MoveTo(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void SetStopDist(float dist)
    {
        agent.stoppingDistance = dist;
    }

}
