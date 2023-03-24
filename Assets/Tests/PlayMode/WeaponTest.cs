using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WeaponTest
{
    GameObject gameObject;
    GameObject enemyGameObject;
    HealthSystem healthSystem;
    Weapon weapon;
    [SetUp]
    public void SetUpTest()
    {
        gameObject = new GameObject();
        enemyGameObject = new GameObject();
        healthSystem = enemyGameObject.AddComponent<HealthSystem>();
        weapon = gameObject.AddComponent<Weapon>();
        weapon.Disable();
    }

    [Test]
    public void HitWithOneDamageReduceOneHealth()
    {
        float baseHealth = healthSystem.Health = 2;
        weapon.Damage = 1;
        weapon.Hit(healthSystem);
        float currentHealth = healthSystem.Health;

        Assert.AreEqual(currentHealth, baseHealth - 1);
    }
    [UnityTest]
    public IEnumerator HitWithOneDamageDestroysEnemy()
    {
        float baseHealth = healthSystem.Health = 2;
        weapon.Damage = 10;
        weapon.Hit(healthSystem);

        yield return new WaitForEndOfFrame();

        Assert.IsTrue(enemyGameObject == null);
    }

}
