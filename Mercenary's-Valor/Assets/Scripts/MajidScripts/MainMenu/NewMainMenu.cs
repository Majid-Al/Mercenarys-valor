using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.Analytics;

public class NewMainMenu : MonoBehaviour
{

    //Majid script Start
    [Header("Menue Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button newGame;


    //Majid Script End


    [SerializeField] private string worldMap;
    // Start is called before the first frame update
    void Start()
    {
        // if there is no datasaved then disable the contenue Button
       // if(DataPersistenceManager.Instance.HasGameData() == false)
        // {
        //    continueButton.interactable = false;
        // }
    }

    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.Instance.NewGame();
        SceneManager.LoadScene(worldMap);
    }
    public void OnContinueClicked()
    {
        DisableMenuButtons();
        SceneManager.LoadScene(worldMap);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void DisableMenuButtons()
    {
        continueButton.interactable = false;
        newGame.interactable = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }




}