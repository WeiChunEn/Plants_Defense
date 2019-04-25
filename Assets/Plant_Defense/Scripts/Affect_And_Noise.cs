using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affect_And_Noise : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        switch(gameObject.tag)
        {
            case "Affect":
                Invoke("Destroy_it", 1.0f);
                break;
            case "Fire_Space":
                Invoke("Destroy_it", 0.1f);
                break;
            case "Music":
                Invoke("Destroy_it", 1.5f);
                break;

        }
        
        
        

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
