using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        player.addSpeed += 0.2f;
    }
}
