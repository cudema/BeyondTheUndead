using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float HP = 0;
    private float speed = 0;


    public float addHP;
    public float addSpeed;
    public int EXP;
    public GameObject damageImage;
    SpriteRenderer enemySprite;
    Rigidbody2D enemyRigidbody;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        move();
    }

    void move()
    {
        Vector2 moveVector;
        moveVector = player.transform.position - transform.position;
        moveVector = moveVector.normalized;

        enemyRigidbody.velocity = moveVector * speed * addSpeed;

        if (enemyRigidbody.velocity.x > 0)
        {
            enemySprite.flipX = true;
        }
        else
        {
            enemySprite.flipX = false;
        }
    }

    public void Hit(float _damage, bool _hitBullet)
    {
        Player playerScript = player.GetComponent<Player>();
        int hitCount = playerScript.numOfHit;
        GameObject DP;

        if (hitCount > 1 && _hitBullet)
        {
            for (; hitCount > 0; hitCount--)
            {
                HP -= _damage * 0.4f;
                DP = Instantiate(damageImage, new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
                DP.GetComponent<DamagePrint>().SetText((int)(_damage * 0.4f));
            }
        }
        else
        {
            HP -= _damage;
            DP = Instantiate(damageImage, new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
            DP.GetComponent<DamagePrint>().SetText((int)_damage);
        }

        if (HP <= 0)
        {
            if (playerScript.boomDamage != 0 && _hitBullet)
            {
                playerScript.Boom(transform.position);
            }
            playerScript.GetEXP(EXP);
            Destroy(gameObject);
        }
    }

    public void SetEnemy(float _speed, int _hp)
    {
        speed = _speed;
        HP = _hp * addHP;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Hit();
        }
    }
}
