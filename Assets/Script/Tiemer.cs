using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiemer : MonoBehaviour
{
    GameManager manager;
    Text text;
    int gameTime;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeText();
    }

    void SetTimeText()
    {
        gameTime = manager.GetGameTime();
        text.text = string.Format("{0:D2} : {1:D2}", gameTime / 60, gameTime % 60);
    }
}
