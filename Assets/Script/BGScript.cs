using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public GameObject player;
    public GameObject BG0;
    public GameObject BGX;
    public GameObject BGY;
    public GameObject BGD;
    GameObject tem;
    int X = 1;
    int Y = 1;
    Vector2 vector = new Vector2(20.48f, 11.52f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBGVector();
        SetBG0();
    }

    void SetBGVector()
    {
        if (player.transform.position.x > BG0.transform.position.x)
        {
            X = 1;
        }
        else
        {
            X = -1;
        }

        if (player.transform.position.y > BG0.transform.position.y)
        {
            Y = 1;
        }
        else
        {
            Y = -1;
        }

        BGX.transform.position = new Vector2(BG0.transform.position.x + (X * vector.x), BG0.transform.position.y);
        BGY.transform.position = new Vector2(BG0.transform.position.x, BG0.transform.position.y + (Y * vector.y));
        BGD.transform.position = new Vector2(BG0.transform.position.x + (X * vector.x), BG0.transform.position.y + (Y * vector.y));
    }

    void SetBG0()
    {
        if (Mathf.Abs(BG0.transform.position.x - player.transform.position.x) > vector.x)
        {
            tem = BG0;
            BG0 = BGX;
            BGX = tem;
        }
        if (Mathf.Abs(BG0.transform.position.y - player.transform.position.y) > vector.y)
        {
            tem = BG0;
            BG0 = BGY;
            BGY = tem;
        }
    }
}
