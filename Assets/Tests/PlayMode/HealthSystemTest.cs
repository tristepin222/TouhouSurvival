using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthSystemTest : IPrebuildSetup
{
    GameObject gameObject;
    HealthSystem healthSystem;
    public void Setup()
    {
        GameObject gameObject = new GameObject();
        healthSystem = gameObject.AddComponent<HealthSystem>();
    }

    [UnityTest]
    public void SetHealthToOneDamageOneReturnsOne()
    {
        float Whenhealth = healthSystem.Health = 2;

        healthSystem.Damage(1);

        Assert.AreEqual(Whenhealth, healthSystem.Health);
    }
    [UnityTest]
    public void SetHealthToZeroThrowsException()
    {
        healthSystem.Health = 0;

        Assert.Throws<EmptyHealthException>(() => healthSystem.Damage(1));
    }
}

