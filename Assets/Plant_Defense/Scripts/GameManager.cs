using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Valve.VR;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum Game_State
    {
        Start,
        Loading,
        Selecting,
        Game,
        End,
        none
    };

    public Game_State _eGame_State;
    public bool _bStart_Game;

    public float _fGame_Time;
    public float _fPlayer_HP;

    public GameObject _gPlayer;
    public GameObject _gStart_Area;
    public Animator _aStart_UI;
    public GameObject _gEnd_Area;
    public GameObject _gBug_Area;

    public Transform m_LogoCamera;
    public Transform m_LogoScene;
    public Renderer m_LogoHex;
    public CanvasGroup m_LogoUI;

    public GameObject _gGame_Camera;
    public GameObject _gController;

    public Image _iTime;
    public Image _iHP;

    

    protected float m_Alpha = 1.0f;
    // Use this for initialization
    void Start ()
    {
        if (m_LogoScene != null && m_LogoCamera != null)
        {
            m_LogoScene.position = m_LogoCamera.position;
        }
        _eGame_State = Game_State.Start;
        _bStart_Game = false;
        _fGame_Time = 90.0f;
        _fPlayer_HP = 100.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_fPlayer_HP <= 0 || _fGame_Time <=0)
        {
            _eGame_State = Game_State.End;
        }

        switch(_eGame_State)
        {
            case Game_State.Start:
                if (SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.Any) || Input.GetKeyDown(KeyCode.F10))
                {
                    //_gGame_Camera.SetActive(true);
                   // m_LogoCamera.position = _gGame_Camera.transform.position;
                    m_LogoCamera.gameObject.GetComponent<Camera>().cullingMask = -1;
                    _aStart_UI.SetTrigger("Open");
                    _gController.SetActive(false);
                    Start_Loading();
                   
                }
                break;
            case Game_State.Loading:
                if (m_LogoHex != null)
                {
                    m_LogoHex.material.SetFloat("_deformation_type_Factor", 1.0f - m_Alpha);
                    Color _BC = m_LogoHex.material.GetColor("_BackFace_Color");
                    m_LogoHex.material.SetColor("_BackFace_Color", new Color(_BC.r, _BC.g, _BC.b, m_Alpha));
                }

                if (m_LogoUI != null)
                {
                    m_LogoUI.alpha = m_Alpha;
                }
                break;
            case Game_State.End:
                _gEnd_Area.SetActive(true);
                _gGame_Camera.SetActive(false);
                _gController.SetActive(true);
                _gBug_Area.SetActive(false);
                if (SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.Any) || Input.GetKeyDown(KeyCode.F10))
                {
                    SceneManager.LoadScene(0);
                }
                    break;
                
        }
        if (_bStart_Game == true && _eGame_State == Game_State.Game)
        {
            _fGame_Time -= Time.deltaTime;
            _iTime.fillAmount = _fGame_Time/90;
            _iHP.fillAmount = _fPlayer_HP / 100;
        }
        //if(_gPlayer.GetComponent<Player>()._iPlayer_HP <= 0)
        //{
        //    _eGame_State = Game_State.End;
        //}
        
	}
    public void Start_Loading()
    {
        DOTween.To(() => m_Alpha, x => m_Alpha = x, 0.0f, 2.0f).SetEase(Ease.OutSine).OnComplete(Loading);
        _eGame_State = Game_State.Loading;
    }
    public void Loading()
    {
        _eGame_State = Game_State.Game;
        _bStart_Game = true;
        _gGame_Camera.SetActive(true);
        _gStart_Area.SetActive(false);
        gameObject.GetComponent<AudioSource>().Play();

    }
}
