using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ClickPlace : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    public AudioClip click;

    private void OnMouseDown()
    {
        SFXSource.clip = click;
        SFXSource.Play();

        // Base
        if (gameObject.name == "PapayaBowl")
        {
            Debug.Log("Papaya");
            Gameflow.plateValue[0] += 1;
        }
        if (gameObject.name == "MangoBowl")
        {
            Debug.Log("Mango");
            Gameflow.plateValue[1] += 1;
        }
        

        // Veggies Bottle
        if (gameObject.name == "Bottle_Chili")
        {
            Debug.Log("Chili");
            Gameflow.plateValue[2] += 1;
        }
        if (gameObject.name == "Bottle_Lime")
        {
            Debug.Log("Lime");
            Gameflow.plateValue[3] += 1;
        }
        if (gameObject.name == "Bottle_Tomato")
        {
            Debug.Log("Tomato");
            Gameflow.plateValue[4] += 1;
        }
        if (gameObject.name == "Bottle_Longbean")
        {
            Debug.Log("Longbean");
            Gameflow.plateValue[5] += 1;
        }


        // Spice
        if (gameObject.name == "Spice_Fish")
        {
            Debug.Log("Plara");
            Gameflow.plateValue[6] += 1;
        }
        if (gameObject.name == "Spice_Shrimp")
        {
            Debug.Log("Shrimp");
            Gameflow.plateValue[7] += 1;
        }
        if (gameObject.name == "Spice_Crab")
        {
            Debug.Log("Crab");
            Gameflow.plateValue[8] += 1;
        }
        if (gameObject.name == "Spice_Sugar")
        {
            Debug.Log("Sugar");
            Gameflow.plateValue[9] += 1;
        }
        if (gameObject.name == "Spice_Noodle")
        {
            Debug.Log("Kanomjean");
            Gameflow.plateValue[10] += 1;
        }
        if (gameObject.name == "Spice_Egg")
        {
            Debug.Log("Salted Egg");
            Gameflow.plateValue[11] += 1;
        }
        

        // Sticky Rice
        if (gameObject.name == "StickyRice")
        {
            Debug.Log("StickyRice");
            Gameflow.plateValue[12] += 1;
        }

        // Trash
        if (gameObject.name == "TrashCan")
            Array.Clear(Gameflow.plateValue, 0, Gameflow.plateValue.Length);

        // Check plateValue
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Gameflow.plateValue.Length; i++)
        {
            sb.Append(Gameflow.plateValue[i]);
            sb.Append(", ");
        }
        Debug.Log(sb.ToString());



    }
}
