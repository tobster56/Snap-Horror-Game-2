﻿
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionCheck : MonoBehaviour
{
    
   public GameObject jerrycanobj;
    public GameObject wrenchobj;
    public static bool lowSecurity = false;
    public static bool mediumSecurity = false;
    public static bool highSecurity = false;
    public static bool masterSecurity = false;
    public  bool jerry = false;
    public bool wrench = false;
    public  bool siren = false;
    private bool pickUplow;
    private bool pickUpmed;
    private bool pickUphigh;
    private bool pickUpmas;
    private bool pickUpjerry;
    private bool pickUpwrench;
    private bool ActivateSiren;
    public GameObject low;
    public GameObject med;
    public GameObject high;
    public GameObject mas;
    public GameObject _siren;
    public GameObject _jerry;
    public GameObject _wrench;



    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == ("Item"))
        {
            if (col.gameObject.name == ("lowSecurity"))
            {

                pickUplow = false;
            }
            if (col.gameObject.name == ("mediumSecurity"))
            {
                pickUpmed = false;

            }
            if (col.gameObject.name == ("highSecurity"))
            {

                pickUphigh = false;

            }
            if (col.gameObject.name == ("masterSecurity "))
            {

                pickUpmas = false;

            }
            if (col.gameObject.name == ("jerry") )
            {

                pickUpjerry = false;

            }
            if (col.gameObject.name == ("wrench") )
            {

                
                pickUpwrench = false;

            }
            if (col.gameObject.name == ("siren"))
            {

                
                ActivateSiren = false;

            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == "End")

        {
            Debug.Log("win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (col.tag == "AA-BT")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.Confined;

        }

        if (col.gameObject.tag == ("Item"))
        {
            if (col.gameObject.name == ("lowSecurity"))
            {

                pickUplow = true;
            }
            if (col.gameObject.name == ("mediumSecurity"))
            {
                pickUpmed = true;
                
            }
            if (col.gameObject.name == ("highSecurity"))
            {

                pickUphigh = true;
                
            }
            if (col.gameObject.name == ("masterSecurity "))
            {

                pickUpmas = true;
                
            }
            if (col.gameObject.name == ("jerry") && wrench == false)
            {
                
                pickUpjerry = true;
                
            }
            if (col.gameObject.name == ("wrench") && jerry == false)
            {

                Debug.Log("wrench true");
                pickUpwrench = true;
               
            }
            if (col.gameObject.name == ("siren") && siren == false)
            {
                
                ActivateSiren = true;

            }
        }
    }


   private void Update()
    {
        
        if (pickUplow == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("low");
                lowSecurity = true;
                Destroy(low);
            }
        }
        if (pickUpmed == true)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                mediumSecurity = true;
                Destroy(med);
            }
        }
        if (pickUphigh == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                highSecurity = true;
                Destroy(high);
            }
        }
        if (pickUpmas == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                masterSecurity = true;
                Destroy(mas);
            }
        }
        if (pickUpjerry == true)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                jerry = true;
                jerrycanobj.SetActive(true);
                Destroy(_jerry);
                pickUpjerry = false;
             

            }
        }
        if (pickUpwrench == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                wrench = true;
                
                Destroy(_wrench);
                pickUpwrench = false;
                wrenchobj.SetActive(true);

            }
        }
        if (ActivateSiren == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                siren = true;
                GameObject.Find("Objects").transform.Find("siren").gameObject.SetActive(true);
                
                ActivateSiren = false;
                
            }
        }
    }

  
   
    
}

