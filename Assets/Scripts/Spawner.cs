using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    Vector2 screenHalfSizeWorldUnits;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize =Random.Range (spawnSizeMinMax.x,spawnSizeMinMax.y);
            Vector2 spawnposition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnposition, Quaternion.Euler(Vector3.forward*spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
 