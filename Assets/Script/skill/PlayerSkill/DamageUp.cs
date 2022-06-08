using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        player.damage += 1;
    }
}
