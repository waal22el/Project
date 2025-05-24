using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class PlayerHealthTests : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth health;
    private HealthBar healthBar;
    private GameObject healthBarGO;

    [SetUp]
    public void Setup()
    {
        player = new GameObject("Player");
        health = player.AddComponent<PlayerHealth>();
        health.maxHealth = 10;
        health.health = 10;
        healthBarGO = new GameObject("HealthBar");
        healthBar = healthBarGO.AddComponent<HealthBar>();
        healthBar.health = healthBarGO;
        health.healthBar = healthBar;
        healthBar.SetMaxHP(10);
        healthBar.SetHP(10);
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player);
    }

    //  Unit Test 1: Taking damage
    [UnityTest]
    public IEnumerator PlayerTakesDamage()
    {
        health.TakeDamage(3);
        yield return null;
        Assert.Less(health.health, 10);
    }

    //  Unit Test 2: Healing
    [UnityTest]
    public IEnumerator PlayerHeals()
    {
        health.TakeDamage(3);
        yield return null;
        float damagedSize = healthBarGO.transform.localScale.x;// Healthbar should be smaller or equal before healing
        health.Heal(2);
        yield return null;
        Assert.AreEqual(9, health.health);
        Assert.Greater(healthBarGO.transform.localScale.x, damagedSize);
        health.Heal(10);
        yield return null;
        Assert.AreEqual(10, health.health);
    }
}
