using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

    public Transform target;
    public AiMotor motor;
    public Animator anim;
    public GameObject dDealer;
    public Stats stats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (target)
        {
            motor.MoveTo(target.position);

            if (Vector3.Distance(target.position, transform.position) > 15f)
                target = null;
            if (Vector3.Distance(target.position, transform.position) < 2.1f)
            {
                
                anim.SetBool("Attack", true);
                if(!anim.GetBool("Dead"))
                    FaceTarget();
                dDealer.SetActive(true);
            }
            else
            {
                anim.SetBool("Attack", false);
                dDealer.SetActive(false);
            }
        }

        anim.SetFloat("Walking", motor.agent.velocity.magnitude / motor.agent.speed, .1f, Time.deltaTime);

        if(stats.HP <= 0)
        {
            anim.SetBool("Dead", true);
            Destroy(gameObject, 2.5f);
        }
        
	}

	public void OnTriggerEnter(Collider other) 
	{
        if(other.CompareTag("Player"))
        {
            target = other.transform;
        }
	}


    public void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
