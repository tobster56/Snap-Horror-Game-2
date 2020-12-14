using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabletUI : MonoBehaviour
{
    public Texture[] textures;
    public int currentTexture;
    public PlayerMovement playerMovement;
    
   
    
    



   public  GameObject tabletcamera;
   




    void Start()
    {
       



    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           
            if(tabletcamera.activeInHierarchy == false)
            {
                playerMovement.speed = 0;
                tabletcamera.SetActive(true);
            }
            else
            {
               
                playerMovement.speed = 12;
                tabletcamera.SetActive(false);
                Debug.Log("beep");
            }
        }
        

        if (Input.GetKeyDown(KeyCode.C))
         {
            
             currentTexture++;
             currentTexture %= textures.Length;
            GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
            Debug.Log("next");
            Debug.Log(currentTexture);
        }

      
    } 

}
