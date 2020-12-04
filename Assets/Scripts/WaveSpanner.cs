using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpanner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    public Text waveCountdownText;
    
    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = $"{countdown:00.00}";
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log("Wave incoming!");
        waveIndex += 1;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
