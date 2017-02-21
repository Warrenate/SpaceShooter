using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class RandomRotatorEntityTest
{
    [TestCase(1.4f)]
    [TestCase(2.5f)]
    [TestCase(3.6f)]
    public void GetRotateResult(float tumble)
    {
        var rotator = GetRotator<int>();
        rotator.Tumble = tumble;
        rotator.GetRotateResult(Arg.Any<float>()).Returns(result => (int)rotator.Tumble * 2);

        var actual = rotator.GetRotateResult(rotator.Tumble);

        Assert.AreEqual((int)rotator.Tumble * 2, actual);
    }

    [Test]
    public void SetRotatorSuccess()
    {
        var rotator = GetRotator<int>();
        var entity = GetEntity<int>();

        entity.SetRotator(rotator);
        entity.GetRotateResult();

        entity.Received(1).GetRotateResult();
    }

    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void SetRotatorFailed()
    {
        var entity = GetEntity<int>();

        entity.SetRotator(null);
        entity.GetRotateResult();
    }

    [TestCase(2.4f)]
    [TestCase(3.5f)]
    [TestCase(4.6f)]
    public void GetEntityRotateResultSuccess(float tumble)
    {
        var entity = GetEntity<int>();
        var rotator = GetRotator<int>();
        rotator.Tumble = tumble;
        Func<float, int> func = param => (int)param * 2;
        rotator.GetRotateResult(Arg.Any<float>()).Returns(param => func(tumble));
        entity.SetRotator(rotator);

        var actual = entity.GetRotateResult();

        Assert.AreEqual(func(tumble), actual);
    }

    private IRandomRotator<T> GetRotator<T>()
    {
        return Substitute.For<IRandomRotator<T>>();
    }

    private RandomRotatorEntity<T> GetEntity<T>()
    {
        return Substitute.For<RandomRotatorEntity<T>>();
    }
}