using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Weapon : MonoBehaviour
{
    public GameObject _gAmmo;
    public GameObject _gFire_Space;
    public GameObject _gShoot_Music;
    public int _iDamage;
    public float _fRange;
    public float _fFireRate;
    private float _fNext_Fire;
    public int _iMaxAmmo;
    public int _iCurrentAmmo;
    public float _fReloadTime;
    public bool _bIsReloading;
    [SerializeField] SteamVR_Action_Boolean _TriggerInput;
    [SerializeField] SteamVR_Input_Sources _InputSource;

    [SerializeField] WeaponLaser _wLaser;
    [SerializeField] LayerMask _lLaserDotMask;
    [SerializeField] Transform _tLaserDot;
    [SerializeField] Transform _tFire_Pos;
    private void Awake()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        _iDamage = 10;
        _fRange = 100f;
        _fFireRate = 0.1f;
        _iMaxAmmo = 20;
        _fReloadTime = 3f;
        _bIsReloading = false;
    }
    // Use this for initialization
    void Start ()
    {
        _iCurrentAmmo = _iMaxAmmo;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _wLaser.transform.position = _tFire_Pos.position;
        _wLaser.transform.rotation = _tFire_Pos.rotation;

        if (_TriggerInput.GetState(_InputSource) && Time.time > _fNext_Fire)
        {
            _fNext_Fire = Time.time + _fFireRate;
            Shoot();
        }
        if (Input.GetMouseButton(0) && Time.time > _fNext_Fire)
        {
            _fNext_Fire = Time.time + _fFireRate;
            Shoot();
        }
        Ray _Ray = new Ray(_tFire_Pos.position, _tFire_Pos.forward);
        RaycastHit _Hit;
        Physics.Raycast(_Ray, out _Hit, 500f, _lLaserDotMask);
        SetLaserDotPosition(_Hit);
    }

    public void Shoot()
    {
        Instantiate(_gAmmo, _tFire_Pos.position, _tFire_Pos.transform.rotation);
        Instantiate(_gFire_Space, _tFire_Pos.position, _tFire_Pos.transform.rotation);
        Instantiate(_gShoot_Music, _tFire_Pos.position, _tFire_Pos.transform.rotation);
    }

    void SetLaserDotPosition(RaycastHit hit)
    {
        if (hit.collider != null)
        {
            _wLaser.SetLength(Vector3.Distance(hit.point, _tFire_Pos.position));
            _tLaserDot.gameObject.SetActive(true);
            _tLaserDot.position = hit.point + hit.normal * 0.001f;
            _tLaserDot.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
        }
        else
        {
            _wLaser.SetLength();
            _tLaserDot.gameObject.SetActive(false);
        }
    }
}
