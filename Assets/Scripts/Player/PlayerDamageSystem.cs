using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    [Header("Material")] 
    [SerializeField] private Renderer sphereRenderer;
    [SerializeField] private Material cristal;
    [SerializeField] private Material hitMaterial;
    private float flashDuration = 0.5f;
    
    public void FlashDamage()
    {
        StopAllCoroutines();
        StartCoroutine(DamageFlash());
    }

    private System.Collections.IEnumerator DamageFlash()
    {
        sphereRenderer.material = hitMaterial;
        yield return new WaitForSeconds(flashDuration);
        sphereRenderer.material = cristal;
    }

}
