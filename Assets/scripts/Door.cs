using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    public bool lowSecurity = CollisionCheck.lowSecurity;
    public bool mediumSecurity = CollisionCheck.mediumSecurity;
    public bool highSecurity = CollisionCheck.highSecurity;
    public bool masterSecurity = CollisionCheck.masterSecurity;

    void Start()
    {

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        lowSecurity = CollisionCheck.lowSecurity;
        mediumSecurity = CollisionCheck.mediumSecurity;
        highSecurity = CollisionCheck.highSecurity;
        masterSecurity = CollisionCheck.masterSecurity;
       

    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "basicDoor")
        {


            if (other.tag == "Player")
            {
                anim.SetBool("DoorOpen", true);
                anim.SetBool("DoorClose", false);
                Debug.Log("door");
            }
            if(other.tag == "AA-BT")
            {
                anim.SetBool("DoorOpen", true);
                anim.SetBool("DoorClose", false);
                Debug.Log("door");
            }

        }
            if (gameObject.tag == "lowDoor")
        {
            if (other.tag == "AA-BT")
            {
                anim.SetBool("DoorOpen", true);
                anim.SetBool("DoorClose", false);
                Debug.Log("door");
            }
            if (lowSecurity == true || mediumSecurity == true || highSecurity == true || masterSecurity == true)
            {
                
                if (other.tag == "Player")
                {
                    anim.SetBool("DoorOpen", true);
                    anim.SetBool("DoorClose", false);
                }
            }

        }
        if (gameObject.tag == "mediumDoor")
        {
            if (other.tag == "AA-BT")
            {
                anim.SetBool("DoorOpen", true);
                anim.SetBool("DoorClose", false);
                Debug.Log("door");
            }
            if (mediumSecurity == true || highSecurity == true || masterSecurity == true)
            {
                Debug.Log("nice");
                if (other.tag == "Player")
                {
                    anim.SetBool("DoorOpen", true);
                    anim.SetBool("DoorClose", false);
                }
            }
        }
        if (gameObject.tag == "highDoor")
        {
            if (other.tag == "AA-BT")
            {
                anim.SetBool("DoorOpen", true);
                anim.SetBool("DoorClose", false);
                Debug.Log("door");
            }
            if (highSecurity == true || masterSecurity == true)
            {
                Debug.Log("nice"); 
                if (other.tag == "Player")
                {
                    anim.SetBool("DoorOpen", true);
                    anim.SetBool("DoorClose", false);
                }
            }
        }
        if (gameObject.tag == "masterDoor")
        {
            
            if (masterSecurity == true)
            {

                if (other.tag == "Player")
                {

                    anim.SetBool("DoorOpen", true);
                    anim.SetBool("DoorClose", false);
                }
            }

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            anim.SetBool("DoorClose", true);
            anim.SetBool("DoorOpen", false);
        }
        if (other.tag == "AA-BT")
        {
            anim.SetBool("DoorClose", true);
            anim.SetBool("DoorOpen", false);
        }

    }
    
    
}
       

