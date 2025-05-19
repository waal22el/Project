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

    //  Unit Test 1: H�lsan minskar korrekt
    [Test]
    public void TakeDamage_ReducesHealthCorrectly()
    {
        bossHealth.TakeDamage(4);
        Assert.AreEqual(6, bossHealth.currentHealth);
    }

    //  Unit Test 2: Bossen d�r n�r h�lsan n�r 0 och f�rst�rs
    [UnityTest]
    public IEnumerator TakeDamage_WhenHealthZeroOrBelow_DestroysBoss()
    {
        bossHealth.TakeDamage(15); // H�lsan g�r till 0 eller l�gre
        yield return null; // V�nta en frame s� Destroy hinner k�ras

        Assert.IsTrue(bossObject == null || bossObject.Equals(null)); // Boss-objektet ska vara f�rst�rt
    }
}

