using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotator : MonoBehaviour, IRandomRotator<Vector3>
{
    public RandomRotatorEntity<Vector3> RandomRotatorEntity;

    [SerializeField]
    private float initTumble;

    private void Awake()
    {
        InitEntity();
    }

    private void InitEntity()
    {
        RandomRotatorEntity = new RandomRotatorEntity<Vector3>();
        RandomRotatorEntity.SetRotator(this);
        RandomRotatorEntity.Tumble = initTumble;
    }

    private void Start()
    {
        SetAngularVelocity(GetComponent<Rigidbody>(), RandomRotatorEntity.GetRotateResult());
    }

    private void SetAngularVelocity(Rigidbody targetRigidbody, Vector3 veclocityVector)
    {
        targetRigidbody.angularVelocity = veclocityVector;
    }

    #region Implements from interface 'IRandomRotator<Vector3>'

    public float Tumble { get; set; }

    public Vector3 GetRotateResult(float tumble)
    {
        return Random.insideUnitSphere * tumble;
    }

    #endregion Implements from interface 'IRandomRotator<Vector3>'
}