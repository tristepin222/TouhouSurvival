using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthSystemTest
{
    GameObject gameObject;
    HealthSystem healthSystem;
    [SetUp]
    public void SetUpTest()
    {
        gameObject = new GameObject();
        healthSystem = gameObject.AddComponent<HealthSystem>();
    }

    [Test]
    public void SetHealthToOneDamageOneReturnsOne()
    {
        float Whenhealth = healthSystem.Health = 2;

        healthSystem.Damage(1);

        Whenhealth--;

        Assert.AreEqual(Whenhealth, healthSystem.Health);
    }

    [UnityTest]
    public IEnumerator DamageToZeroDestroyGameObject()
    {
        GameObject gameObjectToDestroy = new GameObject();
        healthSystem = gameObjectToDestroy.AddComponent<HealthSystem>();
        float Whenhealth = healthSystem.Health = 2;

        healthSystem.Damage(2);

        yield return new WaitForEndOfFrame();

        //unity workaround even if object is destroyed, it's not "null"
        Assert.IsTrue(gameObjectToDestroy == null);
    }
}

