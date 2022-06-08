using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumOfHitUp : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        if (skillLevel == 1)
        {
            player.numOfHit = 3;
        }
        else
        {
            player.numOfHit += 1;
        }    
    }
}
