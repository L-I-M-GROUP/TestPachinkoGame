using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public Button startButton;
    public UIManager uiManager;
    void Start()
    {
        startButton.onClick.AddListener(OnClickStartButton);
    }

    void OnClickStartButton() {
        //print("ok");
        gameObject.SetActive(false);
        uiManager.SetActiveGameplayPanel(true);
    }
}
