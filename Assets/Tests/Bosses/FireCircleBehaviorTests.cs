using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FireCircleBehaviorTests
{
    private GameObject fireCircle;
    private GameObject player;

    [SetUp]
    public void Setup()
    {
        // Create player with mock PlayerHealth
        player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<MockPlayerHealth>();
        player.AddComponent<BoxCollider2D>(); // Needed for trigger to detect it

        // Create FireCircle as a 2D object
        fireCircle = new GameObject("FireCircle");
        fireCircle.AddComponent<SpriteRenderer>(); // Optional
        fireCircle.AddComponent<BoxCollider2D>().isTrigger = true;

        var fireScript = fireCircle.AddComponent<FireCircleBehavior>();
        fireScript.transparency = 1f;

        // Add a default material to prevent null in SetObjectTransparency
        var renderer = fireCircle.GetComponent<Renderer>();
        if (renderer != null)
            renderer.material = new Material(Shader.Find("Sprites/Default"));
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(player);
        Object.DestroyImmediate(fireCircle);
    }

    [UnityTest]
    public IEnumerator Transparency_Decreases_Over_Time()
    {
        var script = fireCircle.GetComponent<FireCircleBehavior>();
        float initialAlpha = script.transparency;

        yield return new WaitForSeconds(1f); // Let it update a bit

        Color color = fireCircle.GetComponent<Renderer>().material.color;

        Assert.Less(color.a, initialAlpha, "Transparency did not decrease over time.");
    }

    [UnityTest]
    public IEnumerator FireCircle_Destroyed_After_Lifetime()
    {
        float waitTime = 5.5f; // Just beyond lifetime (5s)
        yield return new WaitForSeconds(waitTime);

        Assert.IsTrue(fireCircle == null || fireCircle.Equals(null), "FireCircle was not destroyed after its lifetime.");
    }



    // Mock class to test damage
    public class MockPlayerHealth : MonoBehaviour
    {
        public int damageTaken = 0;

        public void TakeDamage(int amount)
        {
            damageTaken += amount;
        }
    }
}
