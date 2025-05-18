using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class IntegrationTest
{
    private GameObject monster;
    private MonsterDamage monsterDamage;
    private PlayerAttack playerAttack;
    private GameObject healthBar;

    [SetUp]
    public void Setup()
    {
        // Create a basic health bar UI
        healthBar = new GameObject("HealthBar");
        healthBar.AddComponent<Image>();

        // Create monster with all required components
        monster = new GameObject("Monster");
        monsterDamage = monster.AddComponent<MonsterDamage>();
        monsterDamage.healthBar = healthBar.GetComponent<Image>();
        monsterDamage.maxHealth = 100f;
        monsterDamage.health = 100f;

        // Add required physics components
        monster.AddComponent<BoxCollider2D>();
        var rb = monster.AddComponent<Rigidbody2D>();
        rb.isKinematic = true; // Prevent physics movement

        // Create player attack system
        var player = new GameObject("Player");
        playerAttack = player.AddComponent<PlayerAttack>();

        // Setup test camera
        var testCamera = new GameObject("TestCamera").AddComponent<Camera>();
        testCamera.tag = "MainCamera";
        playerAttack.playerCamera = testCamera;
    }

    [UnityTest]
    public IEnumerator MonsterTakesDamageWhenPlayerAttacks()
    {
        // Initial state check
        Assert.AreEqual(100f, monsterDamage.health, "Monster should start with full health");

        // Directly call TakeDamage to simulate attack
        monsterDamage.TakeDamage(playerAttack.damage);

        // Wait one frame
        yield return null;

        // Verify damage was applied
        Assert.AreEqual(75f, monsterDamage.health,
            $"Monster health should be {100f - playerAttack.damage} after attack");
    }

    [UnityTest]
    public IEnumerator MonsterDropsItemOnDeath()
    {
        // Create test item
        var testItem = new GameObject("TestDropItem");
        testItem.AddComponent<BoxCollider2D>();

        // Configure drops
        monsterDamage.itemDrops = new GameObject[] { testItem };
        monsterDamage.health = 25f; // Set health low enough to die from one hit

        // Trigger death
        monsterDamage.TakeDamage(playerAttack.damage);

        // Wait for drop
        yield return new WaitForSeconds(0.1f);

        // Verify item was dropped
        var droppedItem = GameObject.Find("TestDropItem(Clone)");
        Assert.IsNotNull(droppedItem, "Monster should drop an item on death");

        // Cleanup
        if (droppedItem != null) Object.DestroyImmediate(droppedItem);
        Object.DestroyImmediate(testItem);
    }

    [TearDown]
    public void Teardown()
    {
        // Cleanup in reverse order
        if (monster != null) Object.DestroyImmediate(monster);
        if (healthBar != null) Object.DestroyImmediate(healthBar);

        // Clean player objects
        var players = GameObject.FindObjectsOfType<PlayerAttack>();
        foreach (var p in players) Object.DestroyImmediate(p.gameObject);

        // Clean cameras
        var cameras = GameObject.FindObjectsOfType<Camera>();
        foreach (var cam in cameras) Object.DestroyImmediate(cam.gameObject);

        // Clean any remaining items
        var items = GameObject.FindObjectsOfType<GameObject>();
        foreach (var item in items)
        {
            if (item.name.Contains("TestDropItem") || item.name.Contains("Clone"))
                Object.DestroyImmediate(item);
        }
    }
}