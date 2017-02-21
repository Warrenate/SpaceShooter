using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IWeapon
{
    float FireRate { get; set; }

    float Delay { get; set; }

    void Fire();
}
