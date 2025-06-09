using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 다양한 적 프리팹 배열
    public float spawnInterval = 2f;
    public float spawnDistance = 10f; // 맵 밖 거리
    public Transform player;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // 플레이어를 기준으로 랜덤한 외곽 방향 결정
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnDistance;

        // 랜덤한 적 프리팹 선택
        int index = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index], spawnPosition, Quaternion.identity);
    }
}
