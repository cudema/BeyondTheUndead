using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    int numOfPenetra = 0;
    Player player;
    Rigidbody2D bulletRigidbody;
    [SerializeField]
    float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        bulletDamage = player.damage;
    }

    // Update is called once per frame
    void Update()
    {
        bulletRigidbody.velocity = transform.right * speed;
        bulletDamage -= player.distanceDamageDown * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletDestroyObj")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Hit(bulletDamage, true);
            if (player.penetrationCount <= numOfPenetra)
            {
                Destroy(gameObject);
            }
            else
            {
                numOfPenetra++;
            }
        }
    }
}
