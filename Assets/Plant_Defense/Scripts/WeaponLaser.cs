using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : MonoBehaviour
{
    [SerializeField] float m_DefaultLength = 200f;

    LineRenderer m_Line;

    private void Awake()
    {
        m_Line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        m_Line.material.SetTextureScale("_MainTex", new Vector2(m_Line.GetPosition(1).z * 5f, 1f));
    }

    public void SetLength(float length)
    {
        if (length > m_DefaultLength)
            length = m_DefaultLength;

        Vector3 _Pos = new Vector3(0f, 0f, length);
        m_Line.SetPosition(1, _Pos);
    }

    public void SetLength()
    {
        SetLength(m_DefaultLength);
    }
}
