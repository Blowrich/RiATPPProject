using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Motor CurrentMotor;
    public Animator Anim;
    public bool InPunch = false;

    public Vector3 currentDirection;
    public float xAxis;
    public float yAxis;
	// Use this for initialization
	void Start ()
    {
        CurrentMotor = GetComponent<Motor>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetAxis();
        if (xAxis != 0 || yAxis != 0)
        {
            Anim.SetBool("Walk", true);
            CurrentMotor.Move(GetDirection());
        }
        else
            Anim.SetBool("Walk", false);

        if (Input.GetMouseButton(0))
        {
            if (!InPunch)
                StartCoroutine(Punch());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentMotor.Jump();
        }
        
	}

    void OnCollisionEnter(Collision col)
    {
            Anim.SetBool("Jump", false);
    }

    void OnCollisionExit(Collision col)
    {
        Anim.SetBool("Jump", true);
    }

    public void GetAxis()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }

    public Vector3 GetDirection()
    {
        Vector3 direction = new Vector3(xAxis, 0, yAxis);
        currentDirection = direction;
        return direction;
    }

    public IEnumerator Punch()
    {
        InPunch = true;
        Anim.SetBool("Punch", true);
        yield return new WaitForSeconds(0.7f);
        Anim.SetBool("Punch", false);
        yield return new WaitForSeconds(0.05f);
        InPunch = false;
    }
}
