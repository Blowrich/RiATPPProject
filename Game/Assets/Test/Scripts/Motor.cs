using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    public float Speed = 1f;
    public float Turn;
    public Rigidbody Rb;

    public float CurrentSpeed;
    Vector3 lastPos;
	// Use this for initialization
	void Start () {
        lastPos = transform.position;
        Rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        CurrentSpeed = Vector3.Distance(transform.position, lastPos) / Time.fixedDeltaTime;
        lastPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Jump()
    {
        Rb.AddForce(Vector3.up * 500f);
    }

    public void Move(Vector3 direction)
    {

        float x = direction.x;
        float y = direction.z;

        float c = Mathf.Sqrt(x * x + y * y);
        if(c != 0)
            transform.position += direction * Speed * Time.deltaTime / c;

        Vector2 a = new Vector2(0, 1);
        Vector2 b = new Vector2(direction.x, direction.z);
        float denominator = (Mathf.Sqrt(a.x * a.x + a.y * a.y) * Mathf.Sqrt(b.x * b.x + b.y * b.y));
        float cosTurn = 0;
        if (denominator != 0)
            cosTurn = Scalar(a, b) / denominator;
        else
            cosTurn = 1;
        Turn = Mathf.Acos(cosTurn) * Mathf.Rad2Deg;
        if (x < 0)
            Turn *= -1f;

        Quaternion newRot = Quaternion.Euler(new Vector3(0, Turn, 0));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 0.1f);
    }

    float Scalar(Vector2 a, Vector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    
}


/*
 
        float x = direction.x;
        float y = direction.z;

        float c = Mathf.Sqrt(x * x + y * y);
        if (c != 0)
        {
            transform.position += direction * Speed * Time.deltaTime / c;
            
        }
        
        Turn = Mathf.Atan(y / x) * Mathf.Rad2Deg;

     */
