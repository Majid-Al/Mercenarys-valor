using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class MainMenu : MonoBehaviour
{

    //Majid script Start
    [Header("Menue Buttons")]
    [SerializeField] private Button contenueButton;
    [SerializeField] private Button newGame;



    //Majid Script End


    [SerializeField] private string whichscene;
    // Start is called before the first frame update
    void Start()
    {
        // majid again ;)
        // check if there is a data saved
        // if there is no datasaved then disable the contenue Button
        //if(DataPersistenceManager.Instance.HasGameData() == false)
       // {
        //    contenueButton.interactable = false;
       // }
        // Majid out
    }

    public void OnNewGameClicked()
    {

    }
    public void OnContinue()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Load()
    {
        SceneManager.LoadScene(whichscene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }




}