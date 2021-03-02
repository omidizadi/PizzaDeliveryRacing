using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private GameObject driveStylePanel;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = DependencyResolver.ResolveSingleton<GameManager>();
        carController.SetState(new FourWheelDrive(new DriftController()));

    }
    
    public void StartTheGame()
    {
        gameManager.StartGame();
    }

    public void SetCarFourWheelDrive()
    {
        carController.SetState(new FourWheelDrive(new DriftController()));
        driveStylePanel.SetActive(false);
    }  
    public void SetCarFrontWheelDrive()
    {
        carController.SetState(new FrontWheelDrive(new DriftController()));
        driveStylePanel.SetActive(false);

    }   
    public void SetCarRearWheelDrive()
    {
        carController.SetState(new RearWheelDrive(new DriftController()));
        driveStylePanel.SetActive(false);

    }

}
