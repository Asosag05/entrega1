using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1;
    public float maxSpawnRatePerMinute = 30;
    public float spawnMargin = 1f;

    private float spawnNext = 0;
    private Camera cam;
    private float xLimit, yLimit;

    void Start()
    {
        cam = Camera.main;
        CalculateScreenLimits();
    }

    void CalculateScreenLimits()
    {
        yLimit = cam.orthographicSize + spawnMargin;
        xLimit = (cam.orthographicSize * cam.aspect) + spawnMargin;
    }

    void Update() 
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute = Mathf.Min(spawnRatePerMinute + spawnRateIncrement, maxSpawnRatePerMinute);

            Vector2 spawnPosition = GetRandomBorderPosition();
            
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomBorderPosition()
    {
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                return new Vector2(Random.Range(-xLimit, xLimit), yLimit);
            case 1:
                return new Vector2(Random.Range(-xLimit, xLimit), -yLimit);
            case 2:
                return new Vector2(-xLimit, Random.Range(-yLimit, yLimit));
            default:
                return new Vector2(xLimit, Random.Range(-yLimit, yLimit));
        }
    }
}

