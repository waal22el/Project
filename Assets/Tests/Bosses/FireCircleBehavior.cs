using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class FireCircleBehavior : MonoBehaviour
{
    [Range(0f, 1f)]
    public float transparency = 1f; // 0 = fully transparent, 1 = fully opaque
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float time = 0f;
    private GameObject player;
    internal bool insideFire = false;


    void Start()
    {
        SetObjectTransparency(transparency);

        player = GameObject.FindWithTag("Player");

        StartCoroutine("DealDamage");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float fractionTime = time / lifetime;

        SetObjectTransparency(transparency * (1 - fractionTime));

        if (time >= lifetime)
            Destroy(gameObject);    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        insideFire = true;
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        insideFire = false;
    }

    public IEnumerator DealDamage()
    {
            // Wait for the first frame if not inside the fire
        if (!insideFire)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(DealDamage());
            yield break;
        }

        // Check if player still exists
        if (player == null)
        {
            yield break;
        }

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            Debug.Log(damage + " Damage dealt");
            int intDamage = Mathf.RoundToInt(damage);
            playerHealth.TakeDamage(intDamage);
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(DealDamage());  
    }
    public void SetObjectTransparency(float alpha)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && renderer.material != null)
        {
            // Set rendering mode to Transparent if needed
            Material material = renderer.material;
            material.SetFloat("_Mode", 3); // 3 = Transparent
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;

            // Change the alpha of the color
            Color color = material.color;
            color.a = alpha;
            material.color = color;
        }
    }
}
