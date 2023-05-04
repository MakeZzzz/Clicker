using System;
using System.Collections.Generic;
using Configs;
using GameView;
using JetBrains.Annotations;
using Models;
using Systems;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BalanceSystem totalBalanceController;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem businessSystem;

    private SaveSystem _json;

    private void Awake()
    {
        _json = new SaveSystem();
        StartGame();
    }

    private void StartGame()
    {
        BusinessModel[] _businessModels;
        var data = _json.Load();
        if (data == null)
        {
            Debug.Log(totalBalanceController.GetBalance());
            _configSystem.CreateBusinessModels();
            _businessModels = _configSystem.GetBuisnessModels();
        }
        else
        {
            _businessModels = data.BusinessModels;
            Debug.Log(data.Balance);

            totalBalanceController.Initialize(data.Balance);
        }

        businessSystem.SpawnBusiness(_businessModels);
    }

    [UsedImplicitly]
    public void ExitWithSaving()
    {
        var businesModels = _configSystem.GetBuisnessModels();

        var balance = totalBalanceController.GetBalance();
        var saveData = new SaveData(balance, businesModels);

        _json.Save(saveData);


        EditorApplication.isPlaying = false;
    }

    [UsedImplicitly]
    public void ExitWithoutSaving()
    {
        _json.Delete();
        businessSystem.DeleteControllers();
        EditorApplication.isPlaying = false;
    }
}