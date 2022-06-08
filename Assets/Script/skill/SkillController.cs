using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillList
{
    public string skillName;
    public int level;
    public int maxLevel;
}

public class SkillController : MonoBehaviour
{
    public GameObject UI;
    public GameObject skillTextUI;
    [SerializeField]
    public SkillList[] skill;

    int[] skillIndex = new int[3];
    int numOfUpgradeableSkill;
    bool UIOn = false;
    PlayerSkill[] skillData;
    Player player;

    private void Awake()
    {
        UI.SetActive(false);
        skillTextUI.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        skillData = new PlayerSkill[skill.Length];
        for (int i = 0; i < skill.Length; i++)
        {
            GameObject obj = new GameObject(skill[i].skillName);
            PlayerSkill ps = obj.AddComponent<PlayerSkill>();
            skillData[i] = ps.SetSkill(i, skill[i].level, skill[i].maxLevel);
            obj.transform.SetParent(this.transform);
        }
    }

    public void OnLevelUpUI()
    {
        StartCoroutine(SetSkillUI());
    }

    IEnumerator SetSkillUI()
    {
        numOfUpgradeableSkill = skill.Length - player.GetMaxLevelSkillCount();
        if (numOfUpgradeableSkill < 1)
        {
            yield break;
        }
        UIOn = true;
        Time.timeScale = 0;
        SetSkillSelectUI();
        UI.SetActive(true);
        skillTextUI.SetActive(true);

        yield return new WaitWhile(() => UIOn);

        UI.SetActive(false);
        skillTextUI.SetActive(false);
        Time.timeScale = 1;
    }

    void SetSkillSelectUI()
    {
        int count = 0;

        if (numOfUpgradeableSkill < 3)
        {
            UI.transform.GetChild(2).gameObject.SetActive(false);
            count++;
            if (numOfUpgradeableSkill < 2)
            {
                UI.transform.GetChild(1).gameObject.SetActive(false);
                count++;
            }
        }

        for (int i = 0; i < UI.transform.childCount - count; i++)
        {
            SetSkillIndex(i);

            UI.transform.GetChild(i).GetComponent<SkillButton>().SetSkillIndex(skillIndex[i], skillData[skillIndex[i]]);
        }
    }

    void  SetSkillIndex(int value)
    {
        skillIndex[value] = Random.Range(0, skill.Length);
        if (value == 0)
        {
            while (!skillData[skillIndex[value]].ChackSkillLevel())
            {
                skillIndex[value] = (skillIndex[value] + 1) % skill.Length;
            }
            return;
        }

        int i = 0;

        while (i < value)
        {
            if (!skillData[skillIndex[value]].ChackSkillLevel() || skillIndex[i] == skillIndex[value])
            {
                skillIndex[value] = (skillIndex[value] + 1) % skill.Length;
                i = 0;
                continue;
            }

            i++;
        }
    }

    public void SkillSelect(int value)
    {
        transform.GetChild(value).GetComponent<PlayerSkill>().SkillLevelUp();

        UIOn = false;
    }
}
