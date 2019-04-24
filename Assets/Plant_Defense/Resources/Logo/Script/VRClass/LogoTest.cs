using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoTest : MonoBehaviour
{
    private void Start()
    {
        transform.position = Camera.main.transform.position;
    }
    // Use this for initialization
    void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position, Time.deltaTime * 0.5f);
	}
}
