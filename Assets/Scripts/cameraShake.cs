using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    [SerializeField] float duration = 2f;
    [SerializeField] float magnitude = 0.5f;

    public void startShake()
    {
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
            elapsedTime += Time.deltaTime;

            yield return null;

        }

        transform.localPosition = originalPos;

    }

}
