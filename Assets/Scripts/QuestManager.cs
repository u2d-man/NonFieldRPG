using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public BattleManager battleManager;
    public StageUIManager stageUI;
    public SceneTransitionManager sceneManager;


    // 1 is enemy encounter, 0 is enemy not encounter
    private readonly int[] _encounterTable = { 1, 0, 1, 1, 0, 1 };

    private int _currentStage;

    private void Start()
    {
        stageUI.UpdateUI(_currentStage);
    }
    
    public void OnNextButton()
    {
        _currentStage++;
        stageUI.UpdateUI(_currentStage);

        if (_encounterTable.Length <= _currentStage)
        {
            QueryClear();
        }
        else if (_encounterTable[_currentStage] == 1)
        {
            EncounterEnemy();
        }
    }

    private void EncounterEnemy()
    {
        stageUI.ShowHideSwitchButton(false);
        var enemyObj = Instantiate(enemyPrefab);
        var enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowHideSwitchButton(true);
    }

    private void QueryClear()
    {
        sceneManager.LoadTo("Town");
    }
}
