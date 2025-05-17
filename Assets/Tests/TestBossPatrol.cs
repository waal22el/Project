using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class BossPatrolTests
{
    private GameObject bossObject;
    private BossPatrol bossPatrol;
    private Rigidbody2D rb;

    [SetUp]
    public void Setup()
    {
        bossObject = new GameObject();
        rb = bossObject.AddComponent<Rigidbody2D>();
        bossPatrol = bossObject.AddComponent<BossPatrol>();
        bossPatrol.moveSpeed = 2f;
        bossPatrol.Start();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(bossObject);
    }

    [UnityTest]
    public IEnumerator Update_SetsCorrectVelocity()
    {
        // Allow physics to process
        yield return new WaitForFixedUpdate();

        bossPatrol.Update();

        // Check that the boss is moving at the correct speed
        Assert.AreEqual(bossPatrol.moveSpeed, rb.linearVelocity.magnitude, 0.1f);
    }

    [Test]
    public void OnCollisionEnter2D_ChangesDirection()
    {
        // Capture initial direction
        Vector2 initialDirection = GetPrivateCurrentDirection();

        // Simulate collision
        bossPatrol.OnCollisionEnter2D(null);
        Vector2 newDirection = GetPrivateCurrentDirection();

        // Verify that the direction actually changed
        Assert.AreNotEqual(initialDirection, newDirection);
    }

    private Vector2 GetPrivateCurrentDirection()
    {
        var field = typeof(BossPatrol).GetField("currentDirection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (Vector2)field.GetValue(bossPatrol);
    }
}

