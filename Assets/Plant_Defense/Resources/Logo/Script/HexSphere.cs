using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HexSphere : MonoBehaviour
{
    public Renderer m_Renderer;
    protected float m_OutlineIntensity = 2.0f;

	// Use this for initialization
	void Start ()
    {
        DOTween.To(() => m_OutlineIntensity, x => m_OutlineIntensity = x, 5.0f, 1.0f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (m_Renderer != null)
        {
            m_Renderer.material.SetFloat("_Outline_Opacity", m_OutlineIntensity);
        }
	}
}
