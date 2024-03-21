using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public TextMeshProUGUI waveCountdownText;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    private int waveIndex = 1;
    
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        waveCountdownText.text = Mathf.Round(countdown).ToString();   

        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        for(int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
