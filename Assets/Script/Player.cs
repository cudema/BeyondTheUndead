using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public int HP;
    public float addSpeed = 1f;
    public float shootCoolDown = 1f;
    public int shootBulletCount = 1;
    public float damage = 0;
    public int penetrationCount;
    public int boomDamage;
    public int numOfHit = 1;
    public int levelUpFigure;
    public float hitCounter = 2f;
    public float distanceDamageDown = 0;
    
    public GameObject bulletPrefeb;
    public GameObject boomPrefeb;
    public HPBar bar;
    public EXPBar expBar;

    private int level = 1;
    private float speed = 2f;
    private float EXP = 0f;
    private float shootTime;
    private int maxLevelSkillCount = 0;
    Camera playerCamara;
    Rigidbody2D playerRigidbody;
    SkillController skillController;
    Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerCamara = transform.GetChild(0).GetComponent<Camera>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        skillController = transform.GetChild(2).GetComponent<SkillController>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hitCounter -= Time.deltaTime;
        Move();
        Shoot();
        LookMouse();
    }

    void Move()
    {
        Vector2 moveVector;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        moveVector = moveVector.normalized;

        playerRigidbody.velocity = (moveVector * speed) * addSpeed;
        if (playerRigidbody.velocity != Vector2.zero)
        {
            playerAnimator.SetBool("IsMove", true);
        }
        else
        {
            playerAnimator.SetBool("IsMove", false);
        }
    }

    void LookMouse()
    {
        Vector2 mousePoint = playerCamara.ScreenToWorldPoint(Input.mousePosition);

        if (mousePoint.x - transform.position.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Shoot()
    {
        shootTime -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            playerAnimator.SetBool("IsAttack", true);
            if (shootTime <= 0)
            {
                StartCoroutine(ShootC());
                shootTime = shootCoolDown;
            }
        }
        else
        {
            playerAnimator.SetBool("IsAttack", false);
        }
    }

    IEnumerator ShootC()
    {
        Vector2 mousePoint = playerCamara.ScreenToWorldPoint(Input.mousePosition);
        Vector3 angle = new Vector3(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(mousePoint.y - transform.position.y, mousePoint.x - transform.position.x));
        int count = shootBulletCount;
        while (count > 0)
        {
            GameObject bullet = Instantiate(bulletPrefeb, transform.position, Quaternion.Euler(angle + new Vector3(0, 0, Random.Range(-7, 7))));

            count--;

            yield return new WaitForSeconds(0.05f);
        }
    }

    void LevelUp()
    {
        level++;
        skillController.OnLevelUpUI();
        levelUpFigure += level / 2;
    }

    public void AddMaxLevelSkill()
    {
        maxLevelSkillCount++;
    }

    public int GetMaxLevelSkillCount()
    {
        return maxLevelSkillCount;
    }

    public void Hit()
    {
        if (hitCounter <= 0)
        {
            playerAnimator.SetTrigger("IsHit");
            HP--;
            bar.SetHpUI(HP);
            hitCounter = 2f;
            if (HP <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameEnd();
    }

    public void GetEXP(float value)
    {
        EXP += value;
        if (EXP >= levelUpFigure)
        {
            EXP = 0;
            LevelUp();
        }
        expBar.SetExpUI((int)EXP, levelUpFigure);
    }

    public void Boom(Vector2 vector)
    {
        GameObject boom = Instantiate(boomPrefeb, vector, Quaternion.identity);
        boom.GetComponent<Boom>().SetBoomDamage(boomDamage);
    }
}
