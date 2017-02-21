using System;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IMover<Vector3>
{
    public MoverEntity<Vector3> MoverEntity;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        InitEntity();
    }

    private void InitEntity()
    {
        MoverEntity = new MoverEntity<Vector3>();
        MoverEntity.SetMover(this);
        MoverEntity.Speed = speed;
    }

    private void Start()
    {
        SetVelocity(GetComponent<Rigidbody>(), MoverEntity.GetVelocity(transform.forward));
    }

    private void SetVelocity(Rigidbody targetRigidbody, Vector3 veclocityVector)
    {
        targetRigidbody.velocity = veclocityVector;
    }

    #region Implements from interface 'IMover<Vector3>'

    public float Speed { get; set; }

    public Vector3 GetVelocity(Vector3 givenFactor, float speed)
    {
        return givenFactor * speed;
    }

    #endregion Implements from interface 'IMover<Vector3>'
}