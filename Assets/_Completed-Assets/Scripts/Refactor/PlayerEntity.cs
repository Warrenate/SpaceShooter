using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerEntity<T>
{
    public Boundary Boundary;
    public float NextFireTime;
    public float Tilt;

    private IMover<T> mover;
    private IWeapon weapon;

    public void SetMover(IMover<T> targetMover)
    {
        mover = targetMover;
    }

    public void SetWeapon(IWeapon targetWeapon)
    {
        weapon = targetWeapon;
    }

    #region Wrap interface 'IMover<T>'

    public float Speed
    {
        get { return mover.Speed; }
        set { mover.Speed = value; }
    }

    public T GetVelocity(T givenFactor)
    {
        return mover.GetVelocity(givenFactor, mover.Speed);
    }

    #endregion Wrap interface 'IMover<T>'

    public virtual bool CanFire(float currentTime)
    {
        return currentTime > NextFireTime;
    }

    public void SetNextFire(float currentTime)
    {
        NextFireTime = currentTime + weapon.FireRate;
    }

    #region Wrap interface 'IWeapon'

    public float FireRate
    {
        get { return weapon.FireRate; }
        set { weapon.FireRate = value; }
    }

    public float Delay
    {
        get { return weapon.Delay; }
        set { weapon.Delay = value; }
    }

    public void Fire(float currentTime)
    {
        if (!CanFire(currentTime))
            return;
        weapon.Fire();
        SetNextFire(currentTime);
    }

    #endregion Wrap interface 'IWeapon'
}

[Serializable]
public struct Boundary
{
    public float XMin;
    public float XMax;
    public float ZMin;
    public float ZMax;
}