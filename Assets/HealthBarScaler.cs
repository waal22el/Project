using UnityEngine;

public class HealthBarScaler : MonoBehaviour
{
    public Vector3 desiredScale = new Vector3(1, 1, 1);

    void LateUpdate()
    {
        if (transform.parent != null)
        {
            Vector3 parentScale = transform.parent.lossyScale;

            // Skydda mot division med noll
            float safeX = parentScale.x != 0 ? parentScale.x : 0.0001f;
            float safeY = parentScale.y != 0 ? parentScale.y : 0.0001f;

            // Z-skalan behövs inte för UI (World Space Canvas)
            transform.localScale = new Vector3(
                desiredScale.x / safeX,
                desiredScale.y / safeY,
                1f // Håll Z-skalan alltid till 1 för UI
            );
        }
    }
}
