using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUp : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        player.shootCoolDown -= 0.2f;
    }
}
