using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class MonsterDamageTests
{
    private GameObject monster;
    private MonsterDamage monsterDamage;

    private GameObject keyPrefab;
    private GameObject itemPrefab;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create monster GameObject
        monster = new GameObject("Monster");
        monsterDamage = monster.AddComponent<MonsterDamage>();
        monsterDamage.health = 10f;

        // Add components
        monster.AddComponent<Rigidbody2D>();
        monster.AddComponent<BoxCollider2D>();
        monsterDamage.healthBar = CreateHealthBarImage();

        // Create mock death effect
        monsterDamage.deathEffect = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        monsterDamage.deathEffect.SetActive(false);

        // Set up item drops
        itemPrefab = new GameObject("ItemDrop");
        itemPrefab.AddComponent<Rigidbody2D>();
        monsterDamage.itemDrops = new GameObject[] { itemPrefab };

        // Set up key drop
        keyPrefab = new GameObject("KeyDrop");
        keyPrefab.AddComponent<Rigidbody2D>();
        monsterDamage.keyPrefab = keyPrefab;
        monsterDamage.keyDropChance = 1.0f; // Force key drop

        yield return null;
    }

    private Image CreateHealthBarImage()
    {
        var canvasGO = new GameObject("Canvas", typeof(Canvas));
        var imageGO = new GameObject("HealthBar", typeof(Image));
        imageGO.transform.parent = canvasGO.transform;
        return imageGO.GetComponent<Image>();
    }

    [UnityTest]
    public IEnumerator Monster_Takes_Damage_And_Dies()
    {
        monsterDamage.TakeDamage(5f);
        Assert.AreEqual(5f, monsterDamage.health, "Health should decrease by 5.");

        monsterDamage.TakeDamage(10f); // This should kill it
        yield return new WaitForSeconds(0.6f); // Wait for Destroy(gameObject, 0.5f);

        Assert.IsTrue(monster == null || !monster, "Monster should be destroyed.");
    }

    [UnityTest]
    public IEnumerator Health_Bar_Updates_Correctly()
    {
        monsterDamage.TakeDamage(5f);
        yield return null;

        float expectedFill = 0.5f;
        float actualFill = monsterDamage.healthBar.fillAmount;

        Assert.AreEqual(expectedFill, actualFill, 0.01f, "Health bar fillAmount should match health percentage.");
    }
}

