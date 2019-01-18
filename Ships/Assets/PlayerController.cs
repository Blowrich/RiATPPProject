using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Motor motor;
    public Vector3 newPoint;
    public Combat combat;
    public LayerMask Layer_Mask;
    public Button L;
    public Button R;
    public float LeftDelay;
    public float RightDelay;
    public Image LI;
    public Image RI;
	// Use this for initialization
	void Start () 
    {
        //Time.timeScale = 0;
        motor = GetComponent<Motor>();
        combat = GetComponent<Combat>();
	}

    public void StartLevel(GameObject btn)
    {
        btn.SetActive(false);
        Time.timeScale = 1;
        L.gameObject.SetActive(true);
        R.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, Layer_Mask))
            {
                if (hit.collider.CompareTag("Ocean"))
                {
                    Debug.Log(hit.point);

                    newPoint = hit.point;
                    motor.Move(newPoint);
                }
            }
        }

        if (Input.GetKey(KeyCode.E))
            combat.rAim.enabled = true;
        else
            combat.rAim.enabled = false;

        if (Input.GetKeyUp(KeyCode.E) && combat.CanShotRight)
        {
            combat.ShotRight();
            RightDelay = 10;
        }

        if (Input.GetKey(KeyCode.Q))
            combat.lAim.enabled = true;
        else
            combat.lAim.enabled = false;

        if (Input.GetKeyUp(KeyCode.Q) && combat.CanShotLeft)
        {
            combat.ShotLeft();
            LeftDelay = 10;
        }


        if(LeftDelay >= 0)
        {
            LeftDelay -= Time.deltaTime;
            LI.fillAmount = LeftDelay / 10f;
        }

        if(RightDelay >= 0)
        {
            RightDelay -= Time.deltaTime;
            RI.fillAmount = RightDelay / 10f;
        }


	}
}
