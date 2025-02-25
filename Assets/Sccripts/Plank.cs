using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{

    public float speedX;
    public float speedY;

    float minX;
    float maxX;

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();

        minX = -Screen.width / 2 + rect.sizeDelta.x / 2; // -1080 / 2 + 100 = -540 +200 = -340
        maxX = Screen.width / 2 - rect.sizeDelta.x / 2; // 1080 / 2 - 200 = 540 - 200 = 340

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 100, transform.localPosition.z);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * x * speedX, Space.World);

        if (transform.localPosition.x < minX) {
            transform.localPosition = new Vector3(minX, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.x > maxX) {
            transform.localPosition = new Vector3(maxX, transform.localPosition.y, transform.localPosition.z);
        }

        float y = Input.GetAxis("Vertical");
        transform.Rotate(-Vector3.forward * y * speedY);
    }
}
