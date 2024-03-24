using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomersCon : MonoBehaviour
{
    // movement speed in units per second
    private float movementSpeed = 1f;

    // Customers's position
    public Transform customerPosition;
    public Transform leavePosition;  

    public static bool isMove = false;
    public static bool isServed = false;
    public static bool isLeave = false;

    public static int customerQ = 0;

    // For Anim
    public Animator animator;
    float speed;
    Vector3 oldPosition;

    public GameObject npcOrder;
    public GameObject npcMenu1, npcMenu2, npcMenu3, npcMenu4, npcMenu5;


    void Start()
    {
        animator = GetComponent<Animator>();
        npcOrder.SetActive(false);
        npcMenu1.SetActive(false);
        npcMenu2.SetActive(false);
        npcMenu3.SetActive(false);
        npcMenu4.SetActive(false);
        npcMenu5.SetActive(false);
    }
        
    void Update()
    {
        // Customer Walk
        isMove = true;
        enterStore();

        speed = Vector3.Distance(oldPosition, transform.position) * 100f;        
        oldPosition = transform.position;

        if(speed < 1f)
        {            
            animator.SetBool("walk", false);
            npcOrder.SetActive(true);

            if (customerQ == 0)
            {
                npcMenu1.SetActive(true);
                npcMenu2.SetActive(false);
                npcMenu3.SetActive(false);
                npcMenu4.SetActive(false);
                npcMenu5.SetActive(false);
            }
            else if (customerQ == 1)
            {
                npcMenu1.SetActive(false);
                npcMenu2.SetActive(true);
                npcMenu3.SetActive(false);
                npcMenu4.SetActive(false);
                npcMenu5.SetActive(false);
            }
            else if (customerQ == 2)
            {
                npcMenu1.SetActive(false);
                npcMenu2.SetActive(false);
                npcMenu3.SetActive(true);
                npcMenu4.SetActive(false);
                npcMenu5.SetActive(false);
            }
            else if (customerQ == 3)
            {
                npcMenu1.SetActive(false);
                npcMenu2.SetActive(false);
                npcMenu3.SetActive(false);
                npcMenu4.SetActive(true);
                npcMenu5.SetActive(false);
            }
            else if (customerQ == 4) 
            {
                npcMenu1.SetActive(false);
                npcMenu2.SetActive(false);
                npcMenu3.SetActive(false);
                npcMenu4.SetActive(false);
                npcMenu5.SetActive(true);
            }
        }
        else 
        {
            animator.SetBool("walk", true);
        }

        // Change to Idle & Order
        orderFood();

        // Customer Walk Out
        leaveStore();

    }

    void enterStore()
    {
        if (isMove == true)
        {
           transform.position = Vector3.Lerp(transform.position, customerPosition.position, movementSpeed * Time.deltaTime);       
        }
    }

    void orderFood() 
    {
        if (transform.position.Equals(customerPosition))
        {
            animator.SetTrigger("stand");
        }
    }

    void leaveStore()
    {
        if (isServed == true)
        {
            checkMenu();
            isServed = false;
            isMove = false;
            animator.SetTrigger("walk");
            checkQueue();
        }
    }

    void checkMenu() 
    {
        if (ServePlate.RightMenu == true)
        {
            animator.SetBool("happy", true);
        }
        else if (ServePlate.RightMenu == false)
        {
            animator.SetBool("angry", true);
        }
    }

    void checkQueue()
    {
        if (customerQ <= 4)
        {
            customerQ += 1;
            Debug.Log("Customer " + (customerQ + 1) + " is Coming");
        }
        if (customerQ == 5) 
        {
            Gameflow.endDay = true;
            npcOrder.SetActive(false);
            Debug.Log("No more customer");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Order")) 
        {
            animator.SetTrigger("stand");
        }
    }



}
