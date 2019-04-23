using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]

public class Bug : MonoBehaviour
{
   
    [Header("方便觀看")]
    public string _sBug_Name;
    public float _fBug_Speed;
    public int _iBug_HP;
    public int _iBug_Money;
    public Slider _sBug_HP;
    public GameObject _gTarget;

    public class Bug_Data
    {
        protected string _sBug_Name;

        protected float _fBug_Speed;
        protected int _iBug_HP;
        protected int _iBug_Money;
    }

    public class Set_Bug : Bug_Data
    {
        public Set_Bug(string Bug_Name, int Bug_HP, float Bug_Speed, int Bug_Money)
        {
            this._sBug_Name = Bug_Name;
            this._iBug_HP = Bug_HP;
            this._fBug_Speed = Bug_Speed;
            this._iBug_Money = Bug_Money;
        }

        public string Bug_Name
        {
            get
            {
                return this._sBug_Name;
            }
        }

        public int Bug_HP
        {
            get
            {
                return this._iBug_HP;
            }

            set
            {
                _iBug_HP = value;
                if (_iBug_HP < 0)
                {
                    _iBug_HP = 0;
                }
            }
        }

        public float Bug_Speed
        {
            get
            {
                return this._fBug_Speed;
            }

            set
            {
                _fBug_Speed = value;
            }
        }

        public int Bug_Money
        {
            get
            {
                return this._iBug_Money;
            }
            set
            {
                _iBug_Money = value;
            }
        }
    }

    Set_Bug Insect;
    public NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    private void Awake()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        _gTarget = GameObject.Find("Player");
       
    }

    void Start()
    {
        Set_Insect();
    }

    // Update is called once per frame
    void Update()
    {
        Debug();
        
        navMeshAgent.SetDestination(_gTarget.transform.position);
    }

    public void Debug()
    {
        _iBug_HP = Insect.Bug_HP;
        _fBug_Speed = Insect.Bug_Speed;

    }

    public void Set_Insect()
    {
        switch (gameObject.name)
        {
           
            case "Bee(Clone)":
                print(123);
                _sBug_Name = "Bee";
                _iBug_HP = 5;
                _fBug_Speed = 5.0f;
                navMeshAgent.speed = _fBug_Speed;
                _iBug_Money = 5;
                Insect = new Set_Bug(_sBug_Name, _iBug_HP, _fBug_Speed, _iBug_Money);
                break;
            case "Ant(Clone)":
                _sBug_Name = "Ant";
                _iBug_HP = 3;
                _fBug_Speed = 3.0f;
                navMeshAgent.speed = _fBug_Speed;
                _iBug_Money = 3;
                Insect = new Set_Bug(_sBug_Name, _iBug_HP, _fBug_Speed, _iBug_Money);
                break;



        }
    }
    
}
