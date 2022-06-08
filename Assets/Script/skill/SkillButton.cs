using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillExplanation
{
    public string name;
    public string explanation;
}

public class SkillButton : MonoBehaviour
{
    public SkillController skillController;
    public Sprite[] skillSprite;
    public Text text;
    public SkillExplanation[] skillText = new SkillExplanation[8];
    PlayerSkill data;
    Button button;
    Image image;
    int index;

    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void SetSkillIndex(int skillIndex, PlayerSkill skillDate)
    {
        data = skillDate;
        index = skillIndex;
        text.text = "";
        image.sprite = skillSprite[index];

        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() => skillController.SkillSelect(index));
    }

    public void SkillTextPrint()
    {
        text.text = skillText[index].name + " [ " + data.skillLevel + " / " + data.maxSkillLevel + " ]\n\n";
        text.text += skillText[index].explanation;
    }

    public void SkillTextClear()
    {
        text.text = "";
    }
}
