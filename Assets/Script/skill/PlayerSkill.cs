using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    protected Player player;
    public int skillLevel;
    public int maxSkillLevel;

    protected void Start()
    {
        player = transform.GetComponentInParent<Player>();
    }
    public virtual void SkillLevelUp()
    {
        skillLevel++;
        if (skillLevel >= maxSkillLevel)
        {
            player.AddMaxLevelSkill();
        }
    }

    public bool ChackSkillLevel()
    {
        return (skillLevel < maxSkillLevel);
    }

    public void SetSkillLevel(int level, int maxLevel)
    {
        skillLevel = level;
        maxSkillLevel = maxLevel;
    }

    public PlayerSkill SetSkill(int i, int level, int maxLevel)
    {
        PlayerSkill data;

        switch (i)
        {
            case 0:
                data = gameObject.AddComponent<AddBullet>();
                break;
            case 1:
                data = gameObject.AddComponent<AttackSpeedUp>();
                break;
            case 2:
                data = gameObject.AddComponent<SpeedUp>();
                break;
            case 3:
                data = gameObject.AddComponent<DistanceDamage>();
                break;
            case 4:
                data = gameObject.AddComponent<NumOfHitUp>();
                break;
            case 5:
                data = gameObject.AddComponent<CorpseBoom>();
                break;
            case 6:
                data = gameObject.AddComponent<DamageUp>();
                break;
            case 7:
                data = gameObject.AddComponent<Penetration>();
                break;
            default:
                data = gameObject.AddComponent<PlayerSkill>();
                break;
        }
        data.SetSkillLevel(level, maxLevel);
        Destroy(gameObject.GetComponent<PlayerSkill>(), 0.1f);
        return data;
    }
}
