using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Enemy>() == null)
            SpawnEnemies(10);

    }

    Vector2 GenerateRandomSpawnPosition()
    {
        float position = Random.Range(0, 48);
        if (position < 17)      return new Vector2(position - 8.5f, 3.5f);
        else if (position < 24) return new Vector2(8.5f, position - 20.5f);
        else if (position < 41) return new Vector2(position - 32.5f, -3.5f);
        else                    return new Vector2(-8.5f, position - 44.5f);
    }

    void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 pos = GenerateRandomSpawnPosition();
            Enemy thisenemy=Instantiate(enemy, pos, Quaternion.identity);
            HealthBar thishealthBar=Instantiate(healthBar,transform);
            thishealthBar.gameObjectAttached = thisenemy;
        }
    }
}
