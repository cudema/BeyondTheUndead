using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    Button button;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

        button.onClick.AddListener(() => gamemanager.GameStart());
    }
}
