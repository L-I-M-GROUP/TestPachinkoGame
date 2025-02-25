using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public StartPanel startPanel;
    public GameplayPanel gameplayPanel;
    public RestartPanel restartPanel;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void SetActiveGameplayPanel(bool _active) {
        gameplayPanel.gameObject.SetActive(_active);
    }

    public void SetActiveRestartPanel(bool _active) {
        restartPanel.gameObject.SetActive(_active);
    }
}
