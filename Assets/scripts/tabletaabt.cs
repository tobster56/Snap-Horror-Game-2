using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabletaabt : MonoBehaviour
{
    public GameObject tabletcamera;
    public bool aabtSight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (aabtSight == true)
            {

                GameObject.Find("Game objects").transform.Find("screenaabt").gameObject.SetActive(false);
                aabtSight = false;

            }
            /* else if(tabletcamera.activeInHierarchy == true)
            {
                
               GameObject.Find("Game objects").transform.Find("screenaabt").gameObject.SetActive(true);
                aabtSight = true;
            
            } */
            

        }
    }
}
