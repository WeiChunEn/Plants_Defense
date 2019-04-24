using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affect_And_Noise : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Invoke("Destroy_it", 1.0f);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Destroy_it()
    {
        Destroy(gameObject);
    }
}
