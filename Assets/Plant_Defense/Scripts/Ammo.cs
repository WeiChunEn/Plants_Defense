using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public GameObject _gHit_Affect;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
         transform.position += transform.forward * Time.deltaTime * 20.0f;
       // transform.position += new Vector3(20.0f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Bump");
        if(other.tag == "Bug")
        {
            print("Hit");
            _gHit_Affect.SetActive(true);
        }
    }


}
