using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ServePlate : MonoBehaviour
{
    // Give Infomation
    bool rightMenu = false;

    public static int[] evidence = {0, 0, 0, 0, 0};

    public GameObject ptransEvi, childEvi, auntieEvi, bnnEvi, taxiEvi;
    public GameObject ptransEvi2, childEvi2, auntieEvi2, bnnEvi2, taxiEvi2;

    public GameObject npcOrder;

    public static bool RightMenu;


    [Header("----- Sound -----")]
    [SerializeField] AudioSource SFXSource;
    public AudioClip click;


    private void Start()
    {

        ptransEvi.SetActive(false);
        childEvi.SetActive(false);
        auntieEvi.SetActive(false);
        bnnEvi.SetActive(false);
        taxiEvi.SetActive(false);

        ptransEvi2.SetActive(false);
        childEvi2.SetActive(false);
        auntieEvi2.SetActive(false);
        bnnEvi2.SetActive(false);
        taxiEvi2.SetActive(false);
    }

    private void OnMouseDown()
    {
        SFXSource.PlayOneShot(click);

        // Check Customer's Menu == Plate's Ingrediants is TRUE
        bool transOrder     = Enumerable.SequenceEqual(Gameflow.plateValue, Gameflow.transNPC);
        bool childOrder     = Enumerable.SequenceEqual(Gameflow.plateValue, Gameflow.childNPC);
        bool auntieOrder    = Enumerable.SequenceEqual(Gameflow.plateValue, Gameflow.auntieNPC);
        bool taxiOrder      = Enumerable.SequenceEqual(Gameflow.plateValue, Gameflow.taxiNPC);
        bool bnnOrder       = Enumerable.SequenceEqual(Gameflow.plateValue, Gameflow.bnnNPC);

        if (transOrder)
        {
            rightMenu = true;
            evidence[0] = 1;
        }
        if (childOrder && CustomersCon.customerQ == 1) 
        {
            rightMenu = true;
            evidence[1] = 1;
        }
        if (auntieOrder && CustomersCon.customerQ == 2)
        {
            rightMenu = true;
            evidence[2] = 1;
        }
        if (taxiOrder && CustomersCon.customerQ == 3)
        {
            rightMenu = true;
            evidence[3] = 1;
        }
        if (bnnOrder && CustomersCon.customerQ == 4)
        {
            rightMenu = true;
            evidence[4] = 1;
        }

        checkMenu();
        addEvidence();

        Array.Clear(Gameflow.plateValue, 0, Gameflow.plateValue.Length);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Gameflow.plateValue.Length; i++)
        {
            sb.Append(Gameflow.plateValue[i]);
            sb.Append(", ");
        }
        Debug.Log(sb.ToString() + "Clear");
        rightMenu = false;
    }

    void checkMenu()
    {
        if (rightMenu)
        {
            CustomersCon.isServed = true;
            rightMenu = true;
            Debug.Log("Served");
        }
        else
        {
            CustomersCon.isServed = true;
            rightMenu = false;
            Debug.Log("Wrong Menu");
        }

        npcOrder.SetActive(false);
    }

    void addEvidence()
    {
        if (evidence[0] == 1) 
        { 
            ptransEvi.SetActive(true);
            ptransEvi2.SetActive(true);
        }
        if (evidence[1] == 1)
        { 
            childEvi.SetActive(true);
            childEvi2.SetActive(true);
        }
        if (evidence[2] == 1) 
        { 
            auntieEvi.SetActive(true);
            auntieEvi2.SetActive(true);
        }
        if (evidence[3] == 1)
        { 
            taxiEvi.SetActive(true);
            taxiEvi2.SetActive(true);
        }
        if (evidence[4] == 1)
        { 
            bnnEvi.SetActive(true);
            bnnEvi2.SetActive(true);
        }

    }
}
