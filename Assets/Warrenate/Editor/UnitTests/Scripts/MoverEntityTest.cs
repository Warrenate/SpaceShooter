using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class MoverEntityTest
{
    [TestCase(5.4f)]
    [TestCase(6.5f)]
    [TestCase(7.6f)]
    public void GetVelocitySuccess(float speed)
    {
        var mover = GetMover<int>();
        Func<float, int> func = param => (int)param * 2;
        mover.GetVelocity(Arg.Any<int>(), Arg.Any<float>()).Returns(result => func(mover.Speed));
        mover.Speed = speed;
        var entity = GetEntity<int>();
        entity.SetMover(mover);
        var expected = func(mover.Speed);

        var actual = entity.GetVelocity(1);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void GetVelocityFailed()
    {
        var entity = GetEntity<int>();

        entity.GetVelocity(1);
    }

    private IMover<T> GetMover<T>()
    {
        return Substitute.For<IMover<T>>();
    }

    private MoverEntity<T> GetEntity<T>()
    {
        return Substitute.For<MoverEntity<T>>();
    }
}