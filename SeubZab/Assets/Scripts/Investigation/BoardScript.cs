using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject Suspect_A, Suspect_F, Suspect_G;

    [Header ("-------------------")]
    public GameObject Deadman;

    [Header("-------------------")]
    public GameObject Rope;
    public GameObject Knife;
    public GameObject Pen;

    public GameObject Letter;
    public GameObject Phone;
    public GameObject Diary;
    [Header("-------------------")]
    public GameObject Close_Button1;
    public GameObject Close_Button2;

    [Header("----- Sound -----")]
    [SerializeField] AudioSource SFXSource;
    public AudioClip button;

    private void OnMouseDown()

    {   SFXSource.clip = button;
        SFXSource.Play();
    }

    private void Start()
    {
        panel.SetActive(false);
        Suspect_A.SetActive(false);
        Suspect_F.SetActive(false);
        Suspect_G.SetActive(false);

        Deadman.SetActive(false);

        Rope.SetActive(false);
        Knife.SetActive(false);
        Pen.SetActive(false);

        Letter.SetActive(false);
        Phone.SetActive(false);
        Diary.SetActive(false);

        Close_Button1.SetActive(false);
        Close_Button2.SetActive(false);

    }

    public void SuspectA() 
    {
        SFXSource.Play();
        panel.SetActive(true);
        Suspect_A.SetActive(true);
        Close_Button1.SetActive(true);
    }

    public void SuspectF() 
    {
        SFXSource.Play();
        panel.SetActive(true);
        Suspect_F.SetActive(true);
        Close_Button1.SetActive(true);
    }

    public void SuspectG()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Suspect_G.SetActive(true);
        Close_Button1.SetActive(true);
    }

    public void Deadperson()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Deadman.SetActive(true);
        Close_Button1.SetActive(true);
    }

    public void eviRope()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Rope.SetActive(true);
        Close_Button2.SetActive(true);
    }

    public void eviKnife()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Knife.SetActive(true);
        Close_Button2.SetActive(true);
    }

    public void eviPen()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Pen.SetActive(true);
        Close_Button2.SetActive(true);
    }

    public void eviLetter()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Letter.SetActive(true);
        Close_Button2.SetActive(true);
    }

    public void eviPhone()
    {
        SFXSource.Play();
        panel.SetActive(true);
        Phone.SetActive(true);
        Close_Button2.SetActive(true);
    }

    public void eviDiary() 
    {
        SFXSource.Play();
        panel.SetActive(true);
        Diary.SetActive(true);
        Close_Button2.SetActive(true);
    }

    public void close1()
    {
        SFXSource.Play();
        panel.SetActive(false);
        Suspect_A.SetActive(false);
        Suspect_F.SetActive(false);
        Suspect_G.SetActive(false);

        Deadman.SetActive(false);

        Close_Button1.SetActive(false);
    }

    public void close2() 
    {
        SFXSource.Play();
        panel.SetActive(false);
        Rope.SetActive(false);
        Knife.SetActive(false);
        Pen.SetActive(false);

        Letter.SetActive(false);
        Phone.SetActive(false);
        Diary.SetActive(false);

        Close_Button2.SetActive(false);
    }
}
