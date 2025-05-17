using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class BossHealthTests
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

    [Test]
    public void TakeDamage_ReducesHealthCorrectly()
    {
        bossHealth.TakeDamage(4);
        Assert.AreEqual(6, bossHealth.currentHealth);
    }

    [UnityTest]
    public IEnumerator TakeDamage_WhenHealthZeroOrBelow_DestroysBoss()
    {
        bossHealth.TakeDamage(15); // Should destroy the boss
        yield return null; // Wait a frame for Destroy to process

        Assert.IsTrue(bossObject == null || bossObject.Equals(null)); // Boss should be destroyed
    }
}
s
