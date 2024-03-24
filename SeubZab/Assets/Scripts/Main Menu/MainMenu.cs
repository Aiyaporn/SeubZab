using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip button;

    public GameObject UI_Menu;
    public GameObject UI_Video;
    public GameObject UI_Credit;
    public GameObject VideoPlayer;

    public VideoPlayer vid;
 
    private enum GameUI_State
    {
        GamePlay, Cutscene, Credit
    }

    GameUI_State currentState;

    private void SwitchUIState(GameUI_State state)
    {
        UI_Menu.SetActive(false);
        UI_Credit.SetActive(false);


        Time.timeScale = 1;

        switch (state)
        {
            case GameUI_State.GamePlay:
                UI_Menu.SetActive(true);
                UI_Video.SetActive(false);
                VideoPlayer.SetActive(false);
                musicSource.Play();
                break;
            case GameUI_State.Cutscene:
                UI_Menu.SetActive(false);
                musicSource.Pause();
                break;
            case GameUI_State.Credit:
                UI_Credit.SetActive(true);
                UI_Menu.SetActive(false);
                break;
            
        }

        currentState = state;
    }


    void Start()
    {
        SwitchUIState(GameUI_State.Cutscene);
        vid.loopPointReached += CheckOver;
        musicSource.clip = background;
        SFXSource.clip = button;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        SwitchUIState(GameUI_State.GamePlay);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchUIState(GameUI_State.GamePlay);
        }
    }

    public void Button_Start()
    {
        SFXSource.Play();
        StartCoroutine(loadScene());
    }

    public void Button_Credit()
    {
        SFXSource.Play();
        SwitchUIState(GameUI_State.Credit);
    }

    public void Button_Close()
    {
        SFXSource.Play();
        SwitchUIState(GameUI_State.GamePlay);
    }

    public void Button_Quit()
    {
        SFXSource.Play();
        StartCoroutine(quitGame());
    }
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Store");
    }

    IEnumerator quitGame()
    {
        yield return new WaitForSeconds(1);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
