using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Random : MonoBehaviour
{
    public bool m_RandomScale, m_RandomRotation; // Randomize flags

    public float m_MinScale, m_MaxScale; // Min/Max scale range
    public float m_MinRotation, m_MaxRotaion; // Min/Max rotation range

    private Vector3 m_DefaultScale; // Default scale

    void Awake()
    {
        // Store default scale
        m_DefaultScale = transform.localScale;
    }

    // Randomize scale and rotation according to the values set in the inspector
    void OnEnable()
    {
        if (m_RandomScale)
            transform.localScale = m_DefaultScale * Random.Range(m_MinScale, m_MaxScale);

        if (m_RandomRotation)
            transform.rotation *= Quaternion.Euler(0, 0, Random.Range(m_MinRotation, m_MaxRotaion));
    }
}
