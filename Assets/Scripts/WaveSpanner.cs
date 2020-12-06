using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpanner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    public GameManager gameManager;

    public Text waveCountdownText;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            enabled = false;
            return;
        }
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = $"{countdown:00.00}";
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds += 1;

        var wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (var i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
