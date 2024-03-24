using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameUIManager : MonoBehaviour
{
    public GameObject UI_Pause, UI_Pause2, UI_InGame, UI_Recipe, UI_Invest, UI_Invest2;    
    public GameObject blockObj;

    

    [Header ("----- Sound -----")]
    [SerializeField] AudioSource SFXSource;
    public AudioClip button;

    private enum GameUI_State
    {
        GamePlay, GamePause, Recipe, Investigation
    }

    GameUI_State currentState;

    private void SwitchUIState(GameUI_State state) 
    {
        UI_Pause.SetActive(false);
        UI_Pause2.SetActive(false);
        UI_Recipe.SetActive(false);
        UI_Invest.SetActive(false);
        UI_Invest2.SetActive(false);


        Time.timeScale = 1;

        switch (state)
        {
            case GameUI_State.GamePlay:
                blockObj.SetActive(false);
                UI_InGame.SetActive(true);
                UI_Invest.SetActive(false);
                UI_Invest2.SetActive(false);
                break;
            case GameUI_State.GamePause:
                Time.timeScale = 0;
                blockObj.SetActive(true);
                UI_Pause.SetActive(true);
                UI_Pause2.SetActive(true);
                UI_InGame.SetActive(false);
                break;
            case GameUI_State.Recipe:
                Time.timeScale = 0;
                blockObj.SetActive(true);
                UI_Recipe.SetActive(true);
                UI_InGame.SetActive(false);
                UI_Invest.SetActive(false);
                UI_Invest2.SetActive(false);
                break;
            case GameUI_State.Investigation:
                Time.timeScale = 0;
                blockObj.SetActive(true);
                UI_Invest.SetActive(true);
                UI_Invest2.SetActive(true);
                UI_InGame.SetActive(false);
                break;
        }

        currentState = state;
    }

    private void Start()
    {
        SwitchUIState(GameUI_State.GamePlay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseUI();
        }
    }

    public void TogglePauseUI()
    {
        if (currentState == GameUI_State.GamePlay)
        {
            SwitchUIState(GameUI_State.GamePause);
        }
        else if (currentState == GameUI_State.GamePause)
        {
            SwitchUIState(GameUI_State.GamePlay);
        }
    }

    

    // In Game_Button
    public void Button_Pause()
    {
        SFXSource.PlayOneShot(button);
        SwitchUIState(GameUI_State.GamePause);
    }

    public void Button_Invest()
    {
        SFXSource.PlayOneShot(button);
        SwitchUIState(GameUI_State.Investigation);
        Debug.Log("Investigation Page");
    }

    public void Button_Recipe()
    {
        SFXSource.PlayOneShot(button);
        SwitchUIState(GameUI_State.Recipe);
        Debug.Log("Recipe Page");
    }

    // Pause_Button
    public void Button_Resume()
    {
        SFXSource.PlayOneShot(button);
        SwitchUIState (GameUI_State.GamePlay);
    }

    public void Button_MainMenu()
    {
        SFXSource.PlayOneShot(button);
        SceneManager.LoadScene("MainMenu");
    }

    // Recipe_Button
    public void Button_Close()
    {
        SFXSource.PlayOneShot(button);
        SwitchUIState(GameUI_State.GamePlay);
    }

    

    
}
