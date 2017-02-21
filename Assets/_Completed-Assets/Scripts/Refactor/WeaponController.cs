using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponController : MonoBehaviour, IWeapon
{
    public WeaponEntity WeaponEntity;
    public GameObject Shot;
    public Transform ShotSpawn;

    [SerializeField]
    private float initFireRate;

    [SerializeField]
    private float initDelay;

    private void Awake()
    {
        InitEntity();
    }

    private void InitEntity()
    {
        WeaponEntity = new WeaponEntity();
        WeaponEntity.SetWeapon(this);
        WeaponEntity.FireRate = initFireRate;
        WeaponEntity.Delay = initDelay;
    }

    private void Start()
    {
        InvokeRepeating("WeaponFire", WeaponEntity.Delay, WeaponEntity.FireRate);
    }

    private void WeaponFire()
    {
        WeaponEntity.Fire();
    }

    #region Implements from interface 'IWeapon'

    public float FireRate { get; set; }

    public float Delay { get; set; }

    public void Fire()
    {
        Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }

    #endregion Implements from interface 'IWeapon'
}