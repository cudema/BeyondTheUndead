using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPScript : MonoBehaviour
{
    float EXPvalue = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().GetEXP(EXPvalue);
            Destroy(gameObject);
        }
    }
}
