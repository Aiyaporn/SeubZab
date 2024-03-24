using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public class Gameflow : MonoBehaviour
{
    // Ingrediants 13 things -----------------------------------------------------------
    public static int[] plateValue = { 0,0,0,0,0,0,0,0,0,0,0,0,0 };

    // Customer's Menu
    public static int[] transNPC    = { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0 };
    public static int[] childNPC    = { 1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1 };
    public static int[] auntieNPC   = { 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0 };
    public static int[] taxiNPC     = { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0 };
    public static int[] bnnNPC      = { 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0 };
    //----------------------------------------------------------------------------------

    [Header("----- Customers's Model -----")]
    // Customer SetActive
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public GameObject NPC5;

    [Header("----- Customers's Position -----")]
    // Customer's Position
    public Transform NPC1position;
    public Transform NPC2position;
    public Transform NPC3position;
    public Transform NPC4position;
    public Transform NPC5position;

    /*[Header("----- Customers's Animation -----")]
    public Animator animator1;*/

    // movement speed in units per second
    private float movementSpeed = 1.2f;

    public static bool endDay = false;

    [Header("----- Position ------------------")]
    public Transform leavePosition;
    public GameObject blockObj;

    [Header("----- Music ---------------------")]
    [SerializeField] AudioSource musicSource;
    public AudioClip background;
    public AudioClip Detective;

    [Header("----- Camera ---------------------")]
    public GameObject Camera1;
    public GameObject Camera2;


    public GameObject UI_Room, UI_Evidence, UI_final, UI_Pause2;

    int choice;

    void Start()
    {
        CameraOne();

        UI_Room.SetActive(false);
        UI_Evidence.SetActive(false);
        UI_final.SetActive(false);

        musicSource.clip = background;
        musicSource.Play();

        NPC1.SetActive(true);
        NPC2.SetActive(false);
        NPC3.SetActive(false);
        NPC4.SetActive(false);
        NPC5.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(waitQueue());
        if (CustomersCon.customerQ == 1)
        {
            NPC1position.position = Vector3.Lerp(NPC1position.position, leavePosition.position, movementSpeed * Time.deltaTime);            
            NPC2.SetActive(true);
            waitOne();
        }     
        if (CustomersCon.customerQ == 2)
        {
            NPC2position.position = Vector3.Lerp(NPC2position.position, leavePosition.position, movementSpeed * Time.deltaTime);
            NPC1.SetActive(false);
            NPC3.SetActive(true);
        }
        if (CustomersCon.customerQ == 3)
        {
            NPC3position.position = Vector3.Lerp(NPC3position.position, leavePosition.position, movementSpeed * Time.deltaTime);
            NPC2.SetActive(false);
            NPC4.SetActive(true);
        }
        if (CustomersCon.customerQ == 4)
        {
            NPC4position.position = Vector3.Lerp(NPC4position.position, leavePosition.position, movementSpeed * Time.deltaTime);
            NPC3.SetActive(false);
            NPC5.SetActive(true);
        }
        if (CustomersCon.customerQ == 5)
        {
            NPC5position.position = Vector3.Lerp(NPC5position.position, leavePosition.position, movementSpeed * Time.deltaTime);
            NPC4.SetActive(false);
            blockObj.SetActive(true);
        }

        if (endDay == true)
        {
            StartCoroutine(changeCam());
            plzStop();
            
        }

    }

    void plzStop() 
    {
        endDay = false;
        musicSource.Pause();
        Debug.Log("Music Pause");
    } 

    void waitOne() 
    {
        StartCoroutine(waitQueue());
    }

    IEnumerator changeCam()
    {
        yield return new WaitForSeconds(3f);
        CameraTwo();
    }
    IEnumerator waitQueue()
    {
        yield return new WaitForSeconds(5f);
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
        UI_Room.SetActive(true);
        UI_Evidence.SetActive(true);
        UI_Pause2.SetActive(true);

        musicSource.clip = Detective;
        musicSource.Play();
    }    

    // Invest_Button
    public void Button_Next()
    {
        UI_Pause2.SetActive(false);
        UI_Evidence.SetActive(false);
        UI_final.SetActive(true);        
    }
    public void Button_CloseCase()
    {
        if (choice == 1)
        {
            SceneManager.LoadScene("BadEnd1");
        }
        else if (choice == 2) 
        {
            SceneManager.LoadScene("BadEnd2");
        }
        else if (choice == 3) 
        {
            SceneManager.LoadScene("GoodEnd");
        }
    }

    public void Suspect1() 
    {
        choice = 1;
    }

    public void Suspect2()
    {
        choice = 2;
    }

    public void Suspect3()
    {
        choice = 3;
    }

}
