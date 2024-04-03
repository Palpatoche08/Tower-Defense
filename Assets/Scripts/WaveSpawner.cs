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


        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text =   (countdown).ToString("F2");  

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
