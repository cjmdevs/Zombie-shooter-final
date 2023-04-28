using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public int enemiesPerWave = 10; // the number of enemies per wave
    public int totalWaves = 5; // the total number of waves
    public string victorySceneName = "VictoryScene"; // the name of the victory scene
    public TextMeshProUGUI waveText; // TextMeshProUGUI to display wave and enemies remaining

    private int currentWave = 1; // the current wave number
    private int remainingEnemies; // the number of enemies remaining in the current wave

    void Start()
    {
        ActivateEnemies();
        remainingEnemies = enemiesPerWave;
        UpdateWaveText();
    }

    void ActivateEnemies()
    {
        // activate enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    void Update()
    {
        // check if all enemies are dead
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            remainingEnemies = 0;
            UpdateWaveText();

            // check if final wave is complete
            if (currentWave >= totalWaves)
            {
                // load victory scene
                SceneManager.LoadScene(victorySceneName);
                return;
            }

            // load next wave scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            currentWave++;
        }
    }

    public void EnemyKilled()
    {
        remainingEnemies--;
        UpdateWaveText();
    }

    void UpdateWaveText()
    {
        waveText.text = "ENEMIES REMAINING: " + remainingEnemies;
    }
}
