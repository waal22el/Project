using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotionSO", menuName = "Scriptable Objects/Items/HealthPotionSO")]
public class HealthPotionSO : ItemSO
{
    public int healing = 5;

    public override void Use()
    {
        GameObject.FindFirstObjectByType<PlayerHealth>().Heal(healing);
    }
}
