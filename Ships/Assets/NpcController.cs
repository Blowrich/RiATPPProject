using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {
    public Motor motor;
    public Vector3 newPoint;
    public Combat combat;
    public GameObject CurrentTarget;
    public SphereCollider Sight;
    public BoxCollider left;
    public BoxCollider right;
    public Transform weapons;
    public OceanOptimization OceanOptimization;
    public string MyTag;
    public string[] Enemies;
	// Use this for initialization
	void Start () {

        motor = GetComponent<Motor>();
        combat = GetComponent<Combat>();
        OceanOptimization = GameObject.FindGameObjectWithTag("Opt").GetComponent<OceanOptimization>();
        //newPoint = OceanOptimization.Waypoints[Random.Range(0, OceanOptimization.Waypoints.Length)].position;
        motor.body.tag = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(CurrentTarget)
        {
            Movement();
            Shooting();
        }
        else
        {
            Patrooling();
        }

        weapons.transform.localPosition = new Vector3(0, 0, -motor.agent.velocity.magnitude);

	}

    public void Patrooling()
    {
        if(Vector3.Distance(newPoint, transform.position) < 1)
        {
            newPoint = OceanOptimization.Waypoints[Random.Range(0, OceanOptimization.Waypoints.Length)].position;
        }
        motor.Move(newPoint);
    }

    void Movement()
    {
        float f = -30;
        float s = 0;
        if (combat.CanShotLeft)
        {
            f = 0;
            s = 10;
        }
        if (combat.CanShotRight)
        {
            f = 0;
            s = -10;
        }
        if(combat.CanShotLeft && combat.CanShotRight)
        {
            f = 0;
            s = 10;
        }

        if(!combat.CanShotLeft && !combat.CanShotRight)
        {
            f = -30;
            s = 0;
        }

        motor.Move(CurrentTarget.transform.position + CurrentTarget.transform.forward * f + transform.right * s);
    }

    void Shooting()
    {
        if(left.bounds.Intersects(CurrentTarget.GetComponent<Motor>().body.bounds))
        {
            //Debug.Log(CurrentTarget.GetComponent<Motor>().body.name);
            combat.ShotLeft();
        }
        if (right.bounds.Intersects(CurrentTarget.GetComponent<Motor>().body.bounds))
        {
            combat.ShotRight();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if(Sight.bounds.Intersects(other.bounds))
        {
            Debug.Log(other.name);
            if (IsEnemy(other.tag))
            {
                CurrentTarget = other.GetComponentInParent<Motor>().gameObject;

            }
        }
	}

    public bool IsEnemy(string tag)
    {
        int k = 0;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if(tag == Enemies[i])
            {
                k++;
                break;
            }
        }

        if (k > 0)
            return true;
        else
            return false;
    }

}
