using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

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


}
