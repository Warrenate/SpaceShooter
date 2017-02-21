using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MoverEntity<T>
{
    private IMover<T> mover;

    public void SetMover(IMover<T> targetMover)
    {
        mover = targetMover;
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
}