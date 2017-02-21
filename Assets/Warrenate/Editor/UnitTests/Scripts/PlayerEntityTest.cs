using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class PlayerEntityTest
{
    [Test]
    public void FireSuccess()
    {
        var weapon = GetWeapon();
        var entity = GetEntity();
        entity.SetWeapon(weapon);
        entity.CanFire(Arg.Any<float>()).Returns(true);

        entity.Fire(1);

        weapon.Received(1).Fire();
        entity.Received(1).SetNextFire(Arg.Any<float>());
    }

    [TestCase(3, 4)]
    [TestCase(5, 7)]
    [TestCase(8, 10)]
    public void GetVelocitySuccess(int factor, float speed)
    {
        var mover = GetMover();
        mover.Speed = speed;
        Func<int, int> func = (param) => param * (int)mover.Speed;
        mover.GetVelocity(Arg.Any<int>(), Arg.Any<float>()).Returns(result => func(factor));
        var entity = GetEntity();
        entity.SetMover(mover);
        var expected = factor * (int)speed;

        var actual = entity.GetVelocity(factor);

        Assert.AreEqual(expected, actual);
    }

    private IMover<int> GetMover()
    {
        return Substitute.For<IMover<int>>();
    }

    private IWeapon GetWeapon()
    {
        return Substitute.For<IWeapon>();
    }

    private PlayerEntity<int> GetEntity()
    {
        return Substitute.For<PlayerEntity<int>>();
    }
}