using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject _gGun;
    public GameObject _gHit_Affect;
	// Use this for initialization
	void Start ()
    {
        _gGun = GameObject.Find("Gun");
        Invoke("Destory_Ammo", 5.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
         transform.position += transform.forward * Time.deltaTime * 20f;
     
    }

    private void OnTriggerEnter(Collider other)
    {
      

        if(other.tag == "Bug")
        {
            Instantiate(_gHit_Affect, other.transform.position,_gHit_Affect.transform.rotation);
            
            other.GetComponent<Bug>().Set_Damage(_gGun.GetComponent<Weapon>()._iDamage);
            Invoke("Destory_Ammo", 0.5f);
           
        }
    }

    public void Destory_Ammo()
    {
        Destroy(gameObject);
    }

   

}
