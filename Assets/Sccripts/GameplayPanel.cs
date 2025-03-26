using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices; // Import để gọi JavaScript từ WebGL

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

    [DllImport("__Internal")]
    private static extern void UnityShowAd(); // Hàm gọi quảng cáo trong JavaScript

    void Start()
    {
        Debug.Log(Screen.width);
        minX = -Screen.width / 2 + offsetX;
        maxX = Screen.width / 2 - offsetX;
        Debug.Log(minX + ", " + maxX);
        StartGame();
    }

    public void StartGame()
    {
        score = 0;
        UpdateScoreText();
        ballList = new List<GameObject>();
        StartCoroutine(SpawnBallCoroutine());
        StartCoroutine(TimeCoroutine());
    }

    IEnumerator SpawnBallCoroutine()
    {
        yield return new WaitForSeconds(1);
        SpawnBallAtRandomPosition();

        yield return new WaitForSeconds(5);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(5);
        SpawnBallAtRandomPosition();

        yield return new WaitForSeconds(3);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(3);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(3);
        SpawnBallAtRandomPosition();
        yield return new WaitForSeconds(1);

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

    void SpawnBallAtRandomPosition()
    {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.SetParent(dropBallTransform);
        ball.transform.localPosition = new Vector3(Random.Range(minX, maxX), 0, 0);
        ballList.Add(ball);
    }

    public bool CheckGameOver()
    {
        Debug.Log("Time left: " + timeSeconds);
        if (timeSeconds == 0)
        {
            FindObjectOfType<Plank>().SetGameOver();

#if UNITY_WEBGL && !UNITY_EDITOR
            UnityShowAd(); // Gọi quảng cáo chỉ khi chạy trên WebGL
#endif

            Invoke("SwitchToRestartPanel", 2.5f); // Chuyển sang màn hình restart sau 2.5 giây
            return true;
        }
        return false;
    }

    public void SwitchToRestartPanel()
    {
        uiManager.SetActiveRestartPanel(true);
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    IEnumerator TimeCoroutine()
    {
        timeSeconds = 30;
        timeText.text = "Time: " + timeSeconds;
        while (timeSeconds > 0)
        {
            yield return new WaitForSeconds(1);
            timeSeconds--;
            timeText.text = "Time: " + timeSeconds;
        }
        CheckGameOver();
    }
}
