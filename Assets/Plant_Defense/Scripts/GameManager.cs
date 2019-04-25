using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Game_State
    {
        Start,
        Selecting,
        Game,
        End,
        none
    };

    public Game_State _eGame_State;
    public bool _bStart_Game;

    public float _fGame_Time;

    public GameObject _gPlayer;
    public GameObject _gEnd_Area;
	// Use this for initialization
	void Start ()
    {
        _eGame_State = Game_State.Start;
        _bStart_Game = false;
        _fGame_Time = 90.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_bStart_Game == true && _eGame_State == Game_State.Game)
        {
            _fGame_Time -= Time.deltaTime;
        }
        if(_gPlayer.GetComponent<Player>()._iPlayer_HP <= 0)
        {
            _eGame_State = Game_State.End;
        }
        
	}
}
