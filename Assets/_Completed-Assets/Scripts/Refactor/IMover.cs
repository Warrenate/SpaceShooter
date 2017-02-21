using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IMover<T>
{
    float Speed { get; set; }

    T GetVelocity(T givenFactor, float speed);
}