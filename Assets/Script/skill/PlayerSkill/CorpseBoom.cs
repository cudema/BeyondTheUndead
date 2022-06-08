using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseBoom : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        if (skillLevel == 1)
        {
            player.boomDamage += 2;
        }
        else
        {
            player.boomDamage += 1;
        }
        
    }
}
