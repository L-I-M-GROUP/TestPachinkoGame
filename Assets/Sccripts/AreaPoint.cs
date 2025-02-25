using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPoint : MonoBehaviour
{
    public int score;
    public GameplayPanel gameplayPanel;

    private void Start() {
        gameplayPanel = GameObject.Find("Gameplay").GetComponent<GameplayPanel>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gameplayPanel.score += score;
        gameplayPanel.UpdateScoreText();
    }
}
