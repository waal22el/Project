using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MonsterChasingTests
{
    private GameObject monster;
    private GameObject player;
    private MonsterChasing chasingScript;
    private Movement movementScript;
    private Rigidbody2D monsterRb;

    public IEnumerator Setup()
    {
       
        monster = new GameObject("Monster");
        player = new GameObject("Player");

        monster.transform.position = Vector3.zero;
        player.transform.position = new Vector3(2f, 0f, 0f);

        monsterRb = monster.AddComponent<Rigidbody2D>();
        monsterRb.gravityScale = 0;
        monsterRb.constraints = RigidbodyConstraints2D.FreezeRotation;

        movementScript = monster.AddComponent<Movement>();
        chasingScript = monster.AddComponent<MonsterChasing>();

        chasingScript.playerTransform = player.transform;
        chasingScript.chaseDistance = 5f;
        chasingScript.moveSpeed = 2f;
        chasingScript.chaseDuration = 1f;

        movementScript.directionChange = 3f;
        movementScript.maxSpeed = 3f;

        yield return null;
    }

    public IEnumerator Teardown()
    {
        Object.Destroy(monster);
        Object.Destroy(player);
        yield return null;
    }

    public IEnumerator StartsChasing_WhenPlayerWithinDistance()
    {
        yield return null;

        Assert.IsTrue(movementScript.isChasing,
            "Monster should start chasing when player is within distance");
    }


    public IEnumerator DoesNotChase_WhenPlayerTooFar()
    {
        player.transform.position = new Vector3(6f, 0f, 0f);

        yield return null;

        Assert.IsFalse(movementScript.isChasing,
            "Monster should not chase when player is too far");
    }


    public IEnumerator StopsChasing_AfterDuration()
    {
        yield return null;
        Assert.IsTrue(movementScript.isChasing, "Precondition: Should be chasing");

        yield return new WaitForSeconds(1.1f);

        Assert.IsFalse(movementScript.isChasing,
            "Monster should stop chasing after duration ends");
    }


    public IEnumerator MovesTowardPlayer_WhileChasing()
    {
        float initialDistance = Vector3.Distance(monster.transform.position, player.transform.position);

        yield return null;
        yield return new WaitForSeconds(0.3f);

        float newDistance = Vector3.Distance(monster.transform.position, player.transform.position);
        Assert.Less(newDistance, initialDistance,
            "Monster should move closer to player while chasing");
    }


    public IEnumerator StopsMoving_WhenNotChasing()
    {
        yield return new WaitForSeconds(0.1f);

        if (!movementScript.isChasing)
        {
            Assert.AreEqual(Vector2.zero, monsterRb.linearVelocity,
                "Rigidbody should have zero velocity when not chasing");
        }
    }
}
