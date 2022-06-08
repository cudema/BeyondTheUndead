using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullet : PlayerSkill
{
    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
        player.shootBulletCount += 1;
    }
}
