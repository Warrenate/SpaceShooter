using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RandomRotatorEntity<T>
{
    private IRandomRotator<T> randomRotator;

    public void SetRotator(IRandomRotator<T> rotator)
    {
        randomRotator = rotator;
    }

    #region Wrap interface 'IRandomRotator<T>'

    public float Tumble
    {
        get { return randomRotator.Tumble; }
        set { randomRotator.Tumble = value; }
    }

    public T GetRotateResult()
    {
        return randomRotator.GetRotateResult(randomRotator.Tumble);
    }

    #endregion Wrap interface 'IRandomRotator<T>'
}