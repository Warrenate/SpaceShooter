using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, IMover<Vector3>, IWeapon
{
    public PlayerEntity<Vector3> PlayerEntity;
    public GameObject Shot;
    public Transform ShotSpawn;

    [SerializeField]
    private float initSpeed;

    [SerializeField]
    private float initTilt;

    [SerializeField]
    private float initFireRate;

    [SerializeField]
    private Boundary initBoundary;

    private void Awake()
    {
        InitEntity();
    }

    private void InitEntity()
    {
        PlayerEntity = new PlayerEntity<Vector3>();
        PlayerEntity.SetMover(this);
        PlayerEntity.SetWeapon(this);
        PlayerEntity.Speed = initSpeed;
        PlayerEntity.Tilt = initTilt;
        PlayerEntity.FireRate = initFireRate;
        PlayerEntity.Boundary = initBoundary;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerEntity.Fire(Time.time);
        }
    }

    private void FixedUpdate()
    {
        SetVelocityOf(GetComponent<Rigidbody>(), Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        SetPositionOf(GetComponent<Rigidbody>(), PlayerEntity.Boundary);
        SetRotationOf(GetComponent<Rigidbody>(), PlayerEntity.Tilt);
    }

    private void SetVelocityOf(Rigidbody targetRigidbody, float moveHorizontal, float moveVertical)
    {
        targetRigidbody.velocity = PlayerEntity.GetVelocity(new Vector3(moveHorizontal, 0, moveVertical));
    }

    private void SetPositionOf(Rigidbody targetRigidbody, Boundary givenBoundary)
    {
        Vector3 rigidbodyPosition = targetRigidbody.position;
        float x = Mathf.Clamp(rigidbodyPosition.x, givenBoundary.XMin, givenBoundary.XMax);
        float z = Mathf.Clamp(rigidbodyPosition.z, givenBoundary.ZMin, givenBoundary.ZMax);
        targetRigidbody.position = new Vector3(x, 0, z);
    }

    private void SetRotationOf(Rigidbody targetRigidbody, float givenTilt)
    {
        targetRigidbody.rotation = Quaternion.Euler(0, 0, targetRigidbody.velocity.x * -givenTilt);
    }

    #region Implements from interface 'IMover<out T>'

    public float Speed { get; set; }

    public Vector3 GetVelocity(Vector3 givenFactor, float speed)
    {
        return givenFactor * speed;
    }

    #endregion Implements from interface 'IMover<out T>'

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