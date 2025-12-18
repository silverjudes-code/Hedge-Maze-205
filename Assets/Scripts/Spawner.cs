using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject diamond;
    public GameObject gem;
    public GameObject jewel;
    public GameObject pentagon;
    public GameObject plumbob;  
    public int enemyCount = 10;
    public float minX = -18;
    public float maxX = 22;
    public float minY = 6;
    public float maxY = 34;
    public float minZ = 40;
    public float maxZ = 193;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = RandomPosition();
            Instantiate(diamond, spawnPos, Quaternion.identity);
        }
                
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = RandomPosition();
            Instantiate(gem, spawnPos, Quaternion.identity);
        }
                
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = RandomPosition();
            Instantiate(jewel, spawnPos, Quaternion.identity);
        }
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = RandomPosition();
            Instantiate(pentagon, spawnPos, Quaternion.identity);
        }
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = RandomPosition();
            Instantiate(plumbob, spawnPos, Quaternion.identity);
        }
    }

    Vector3 RandomPosition()
    {
        return new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            Random.Range(minZ, maxZ)
        );
    }
}

