using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetration : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        player.penetrationCount += 2;
    }
}
