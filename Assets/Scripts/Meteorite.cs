using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public GameObject miniMeteoritePrefab;
    public int miniMeteoriteCount = 2;
    public bool isMini = false; // true si es un mini meteorito, para no generar más hijos
    public float spawnOffset = 0.5f;

    public void Die()
    {
        if (!isMini && miniMeteoritePrefab != null)
        {
            for (int i = 0; i < miniMeteoriteCount; i++)
            {
                Vector2 randomDir = Random.insideUnitCircle.normalized;
                Vector3 spawnPos = transform.position + (Vector3)(randomDir * spawnOffset);
 
                Instantiate(miniMeteoritePrefab, spawnPos, Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }
}
