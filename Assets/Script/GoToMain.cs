using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GoToMain : MonoBehaviour
{
    public VideoPlayer gameOver;
    bool isGoReady = false;
    float tem;

    private void Start()
    {
        tem = gameOver.targetCameraAlpha;
        StartCoroutine(GoMain());
    }
    private void Update()
    {
        tem = Mathf.Lerp(tem, 1, Time.deltaTime * 1);
        gameOver.targetCameraAlpha = tem;
        if (gameOver.targetCameraAlpha >= 0.9)
        {
            isGoReady = true;
        }
    }

    IEnumerator GoMain()
    {
        yield return new WaitUntil(() => isGoReady);

        yield return new WaitUntil(() => Input.anyKeyDown);

        GameManager.LoadMain();

    }
}
