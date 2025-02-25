using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartPanel : MonoBehaviour
{
    public Button restartButton;
    public UIManager uiManager;
    public GameplayPanel gameplay;
    void Start()
    {
        restartButton.onClick.AddListener(OnClickRestartPanel);
    }

    void OnClickRestartPanel() {
        uiManager.SetActiveRestartPanel(false);
        gameplay.StartGame();
    }
}
