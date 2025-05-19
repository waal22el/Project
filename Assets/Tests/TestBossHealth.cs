using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class TestBossHealth
{
    private GameObject bossObject;
    private BossHealth bossHealth;

    [SetUp]
    public void Setup()
    {
        bossObject = new GameObject();
        bossHealth = bossObject.AddComponent<BossHealth>();
        bossHealth.maxHealth = 10;
        bossHealth.Start();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(bossObject);
    }

    //  Unit Test 1: Hälsan minskar korrekt
    [Test]
    public void TakeDamage_ReducesHealthCorrectly()
    {
        bossHealth.TakeDamage(4);
        Assert.AreEqual(6, bossHealth.currentHealth);
    }

    //  Unit Test 2: Bossen dör när hälsan når 0 och förstörs
    [UnityTest]
    public IEnumerator TakeDamage_WhenHealthZeroOrBelow_DestroysBoss()
    {
        bossHealth.TakeDamage(15); // Hälsan går till 0 eller lägre
        yield return null; // Vänta en frame så Destroy hinner köras

        Assert.IsTrue(bossObject == null || bossObject.Equals(null)); // Boss-objektet ska vara förstört
    }
}

