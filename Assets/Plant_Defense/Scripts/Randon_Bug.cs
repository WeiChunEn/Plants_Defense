using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randon_Bug : MonoBehaviour
{
    public GameObject[] _gBug;
    
    public GameObject  _gBug_Point;
   
    public GameObject _gBug_Area;

    public GameObject _gGameManager;
   
    public int _iRandon_Bug;
    
    public float _fStart_Time;
    public float _fRandom_Time;

    private void Awake()
    {
        _fStart_Time = 0.0f;
        _fRandom_Time = 3.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gGameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(_gGameManager.GetComponent<GameManager>()._bStart_Game == true)
        {
            _fStart_Time += Time.deltaTime;
            if (_fStart_Time >= _fRandom_Time)
            {
                _fStart_Time = 0.0f;
                Ins_Bug();

            }
        }
        
    }

    public void Ins_Bug()
    {
        
        _iRandon_Bug = Random.Range(0, 3);
        Instantiate(_gBug[_iRandon_Bug], _gBug_Point.transform.position, _gBug[_iRandon_Bug].transform.rotation,_gBug_Area.transform);
    }

   
}
