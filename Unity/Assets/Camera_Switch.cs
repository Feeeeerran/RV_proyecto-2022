using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Switch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;


    void Update()
    {
        
        if (Input.GetButtonDown("1key")) //Presiono 1 y se activa la vista de 3ra persona
        {
           

            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
        }
        if(Input.GetButtonDown("2key")) //Presiono 1 y se activa la vista de 3ra persona
        {


            cam2.SetActive(true);
            cam1.SetActive(false);
            cam3.SetActive(false);
        }
        if(Input.GetButtonDown("3key")) //Presiono 1 y se activa la vista de 3ra persona
        {


            cam3.SetActive(true);
            cam1.SetActive(false);
            cam2.SetActive(false);
        }
    }
}
