using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHealthSystemTest
{
    GameObject gameObject;
    PlayerHealthSystem playerHealthSystem;
    EffectPlayer effectPlayer;
    Rigidbody2D rigidbody2D;
    FightSystem fightSystem;
    [SetUp]
    public void SetUpTest()
    {
        gameObject = new GameObject();
        playerHealthSystem = gameObject.AddComponent<PlayerHealthSystem>();
        effectPlayer = gameObject.AddComponent<EffectPlayer>();
        rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        fightSystem = gameObject.AddComponent<FightSystem>();
        playerHealthSystem.rigidbody2D = rigidbody2D;
    }

    [Test]
    public void SetHealthToOneDamageOneReturnsOne()
    {
        float Whenhealth = playerHealthSystem.Health = 2;

        playerHealthSystem.Damage(1);

        Whenhealth--;

        Assert.AreEqual(Whenhealth, playerHealthSystem.Health);
    }

    [UnityTest]
    public IEnumerator DamageToZeroDoesNotDestroyGameObject()
    {
        float Whenhealth = playerHealthSystem.Health = 2;

        playerHealthSystem.Damage(2);

        yield return new WaitForEndOfFrame();

        //unity workaround even if object is destroyed, it's not "null"
        Assert.IsTrue(gameObject != null);
    }
    [Test]
    public void NullEffectRigidbody2DException()
    {
        playerHealthSystem.rigidbody2D = null;
        Assert.Throws<EmptyException.EmptyRigidbody2DException>(() => playerHealthSystem.Damage(2));
    }
}
