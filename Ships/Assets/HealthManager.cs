using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public GameObject Main;
    public float Health = 100f;
    public TextMesh bar;
    public Color cl;
    public GameObject exp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Health < 0)
        {

            Instantiate<GameObject>(exp, transform.position, Quaternion.identity);
            Destroy(Main);
        }

        if (bar)
        {
            bar.text = Health.ToString("##.");
            bar.color = cl;
            bar.transform.rotation = Camera.main.transform.rotation;
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Ball")
        {
            float damage = 2 * (10 - Vector3.Distance(other.transform.position, transform.position));
            SpecialBullet sb = other.GetComponent<SpecialBullet>();
            if (sb)
            {
                if(sb.MyTag == gameObject.tag)
                {
                    sb.MyHealth.Health += damage / 2;
                }
            }
                
            Health -= damage;
            GameObject cl = Instantiate<GameObject>(exp, other.transform.position, Quaternion.identity);
            cl.transform.localScale = Vector3.one;
            Destroy(other.gameObject);
        }
	}
}
