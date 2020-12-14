using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public bool _can;
    public float genTimeWrench;
    public float genTimeJerry;
    public CollisionCheck collisionCheck;

    public PlayerMovement playerMovement;



    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player Trigger")
        {
           
            _can = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player Trigger")
        {
            _can = false;
        }
    }
    

    private void Update()
    {
        
        if (_can == true)
        {
            if ( Input.GetKeyDown(KeyCode.E))
            {
                
                if (collisionCheck.wrench == false && genTimeWrench < 5)
                {
                    Debug.Log("you need a wrench");
                }
                if (collisionCheck.jerry == false && genTimeJerry < 5)
                {
                    Debug.Log("you need a jerry can");
                }

            }

            if (Input.GetKey(KeyCode.E))
            {
                if (collisionCheck.wrench == true && genTimeWrench < 5)
                {
                    playerMovement.speed = 0;
                    genTimeWrench += 1 * Time.deltaTime;
                    GameObject.Find("Canvas").transform.Find("wrench Slider").gameObject.SetActive(true);

                }
                else if (collisionCheck.wrench == true)
                {
                    GameObject.Find("Canvas").transform.Find("wrench Slider").gameObject.SetActive(false);
                    GameObject.Find("FirstPersonPlayer").transform.Find("wrench").gameObject.SetActive(false);
                    collisionCheck.wrench = false;


                }


                if (collisionCheck.jerry == true && genTimeJerry < 5)
                {
                    playerMovement.speed = 0;
                    genTimeJerry += 1 * Time.deltaTime;
                    GameObject.Find("Canvas").transform.Find("jerry Slider").gameObject.SetActive(true);

                }
                else if (collisionCheck.jerry == true)
                {
                    collisionCheck.jerry = false;
                    GameObject.Find("FirstPersonPlayer").transform.Find("jerry").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("jerry Slider").gameObject.SetActive(false);
                }



            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            GameObject.Find("Canvas").transform.Find("jerry Slider").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("wrench Slider").gameObject.SetActive(false);
            playerMovement.speed = 12f;
            
        }

        if (genTimeJerry >= 5 && genTimeWrench >= 5)
        {
            GameObject.Find("lightsg").transform.Find("lights").gameObject.SetActive(true);
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("siren");

            foreach (GameObject go in gameObjectArray)
            {

                go.SetActive(false);
            }
            
            
        }
    }
}
