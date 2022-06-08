using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePrint : MonoBehaviour
{
    Canvas canvas;
    public Text text;
    Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        textColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        textColor.a = Mathf.Lerp(textColor.a, 0, Time.deltaTime * 3);
        text.color = textColor;
        if (text.color.a <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(int damage)
    {
        text.text = "" + damage;
    }
}
