using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;

    private void Start()
    {
        CameraOne();
    }

    void Update()
    {      

        if (Gameflow.endDay == true)
        {
            Debug.Log("End Day");
            StartCoroutine(changeCam());
        }

    }

    IEnumerator changeCam() 
    {
        yield return new WaitForSeconds(3f);
        CameraTwo();
    }

    void CameraOne()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
    }

    void CameraTwo()
    {
        Camera2.SetActive(true);
        Camera1.SetActive(false);
    }

}
