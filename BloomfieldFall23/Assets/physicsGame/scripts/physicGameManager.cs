using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class physicGameManager : MonoBehaviour
{
    [Header("Game Vars")]
    public float timer;
    public float enemyTimer;
    public TextMeshProUGUI currentTime;
    public float spawnInterval = 2f;

    [Header("Player Vars")]
    public GameObject myPlayer;

    [Header("Enemy Vars")]
    public Vector2 spawnBounds;
    public GameObject myEnemy;
    public NPCWave[] spawnWaves;
    public int waveCount;



    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        enemyTimer += Time.fixedDeltaTime;

        if(enemyTimer > spawnInterval)
        {

            enemyTimer = 0f;

            GameObject[] newWave = spawnWaves[waveCount].myNPCs;
            for(int i = 0; i < newWave.Length; i++)
            {
                enemyTimer = 0f;
                Vector3 targetPos = Random.insideUnitSphere;
                float mult = Random.Range(spawnBounds.x, spawnBounds.y);
                targetPos *= mult;
                targetPos.y = 1f;
                Instantiate(newWave[i], targetPos, Quaternion.identity);
            }

            waveCount++;
        }
    }


}
