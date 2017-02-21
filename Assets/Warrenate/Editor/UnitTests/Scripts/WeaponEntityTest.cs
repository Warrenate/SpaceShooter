using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class WeaponEntityTest
{
    [Test]
    public void FireSuccess()
    {
        var weapon = GetWeapon();
        var entity = GetEntity();
        entity.SetWeapon(weapon);

        entity.Fire();

        weapon.Received(1).Fire();
    }

    private IWeapon GetWeapon()
    {
        return Substitute.For<IWeapon>();
    }

    private WeaponEntity GetEntity()
    {
        return Substitute.For<WeaponEntity>();
    }
}