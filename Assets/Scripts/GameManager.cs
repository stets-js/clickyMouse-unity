using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour

{
    public List<GameObject> objects;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public Button restartBtn;
    public GameObject titleScreen;
    public int scoreNum = 0;
    public int livesNum = 3;
    private float spawnInterval = 1.0f;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObject()
    {
        while (isGameActive)
        {
        yield return new WaitForSeconds(spawnInterval);
        int idx = Random.Range(0, objects.Count);
        Instantiate(objects[idx]);
        
        }
    }

   public void UpdateScore(int scoreToAdd)
    {
        scoreNum += scoreToAdd;
        scoreText.text = "Score: " + scoreNum;
    }
    public void UpdateLives(int minusLive)
    {
        livesNum -= minusLive;
        livesText.text = "Lives: " + livesNum;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnInterval /= difficulty;
        StartCoroutine(SpawnObject());
        UpdateScore(0);
        UpdateLives(0);
    }
}
