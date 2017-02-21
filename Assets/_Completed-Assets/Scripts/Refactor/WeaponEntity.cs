using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WeaponEntity
{
    private IWeapon weapon;

    public void SetWeapon(IWeapon targetWeapon)
    {
        weapon = targetWeapon;
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

    public void Fire()
    {
        weapon.Fire();
    }

    #endregion Wrap interface 'IWeapon'
}