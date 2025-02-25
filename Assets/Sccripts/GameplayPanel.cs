using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayPanel : MonoBehaviour
{
    public GameObject ballPrefab;
    public UIManager uiManager;
    public Transform dropBallTransform;

    float minX;
    float maxX;
    float offsetX = 100;

    public int score;
    public TextMeshProUGUI scoreText;

    public List<GameObject> ballList;

    public int timeSeconds;
    public TextMeshProUGUI timeText;

    void Start()
    {
        minX = -Screen.width / 2 + offsetX; // -1080 / 2 + 100 = -540 +100 = -440
        maxX = Screen.width / 2 - offsetX; // 1080 / 2 - 100 = 540 - 100 = 440
        StartGame();
    }

    public void StartGame() {
        score = 0;
        UpdateScoreText();
        ballList = new List<GameObject>();
        StartCoroutine(SpawnBallCoroutine());
        StartCoroutine(TimeCoroutine());
    }

    IEnumerator SpawnBallCoroutine() {
        yield return new WaitForSeconds(1);
        SpawnBallAtRandomPosition();

        // 10s dau tien
        yield return new WaitForSeconds(5);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(5);
        SpawnBallAtRandomPosition();

        // 10s thu hai
        yield return new WaitForSeconds(3);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(3);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(3);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(1);

        // 10s thu ba
        yield return new WaitForSeconds(2);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(2);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(2);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(2);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(2);
        SpawnBallAtRandomPosition();
    }

    void SpawnBallAtRandomPosition() {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.SetParent(dropBallTransform);
        ball.transform.localPosition = new Vector3(Random.Range(minX, maxX), 0, 0);
        ballList.Add(ball);
    }

    public bool CheckGameOver() {
        if (ballList.Count == 0) {
            return true;
        }
        return false;
    }

    public void SwitchToRestartPanel() {
        uiManager.SetActiveRestartPanel(true);
    }

    public void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }

    IEnumerator TimeCoroutine() {
        timeSeconds = 10;
        timeText.text = "Time: " + timeSeconds;
        while (timeSeconds > 0) {
            yield return new WaitForSeconds(1);
            timeSeconds--;
            timeText.text = "Time: " + timeSeconds;
        }
    }
}
