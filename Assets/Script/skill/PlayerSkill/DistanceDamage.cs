using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDamage : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        player.damage += 0.5f;
        if (skillLevel == 1)
        {
            player.distanceDamageDown = 3;
        }
        else
        {
            player.distanceDamageDown -= 0.4f;
        }
    }
}
