using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    GameplayPanel gameplay;
    private void Start() {
        gameplay = GameObject.Find("Gameplay").GetComponent<GameplayPanel>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            gameplay.ballList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            if (gameplay.CheckGameOver() == true) {
                gameplay.SwitchToRestartPanel();
            }
        }
    }
}
