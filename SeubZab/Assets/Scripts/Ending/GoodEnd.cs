using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GoodEnd : MonoBehaviour
{
    public VideoPlayer vid;

    void Start()
    {
        vid.loopPointReached += CheckOver;
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");

    }
}
