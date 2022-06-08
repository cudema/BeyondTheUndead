using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Boom : MonoBehaviour
{
    int damage;
    public Animator anime;

    private void Start()
    {
        StartCoroutine(BoomObj());
    }

    IEnumerator BoomObj()
    {
        yield return new WaitUntil(() => anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

        Destroy(gameObject);
    }

    public void SetBoomDamage(int value)
    {
        damage = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hit(damage, false);
        }
    }
}
