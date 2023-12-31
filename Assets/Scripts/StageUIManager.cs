using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject toTownButton;

    public void UpdateUI(int currentStage)
    {
        stageText.text = $"HP：{currentStage + 1}";
    }

    public void ShowHideSwitchButton(bool isShow)
    {
        nextButton.SetActive(isShow);
        toTownButton.SetActive(isShow);
    }
}
