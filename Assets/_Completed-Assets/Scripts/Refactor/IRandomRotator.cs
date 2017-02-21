using System;
using System.Collections.Generic;

public interface IRandomRotator<out T>
{
    float Tumble { get; set; }

    T GetRotateResult(float tumble);

}

