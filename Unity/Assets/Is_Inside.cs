using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_Inside : MonoBehaviour
{
    public bool isInBox;

    public GameObject Cubo;
    public GameObject Car;
    public GameObject Valla_1;
    public Material material_1;
    public Material material_2;

    public float contador1 = 0;
    public float contador2 = 0;
    public float contador3 = 0;
    public float contador4 = 0;

    public float contador = 0;

    private float cambio_material = 0;

    public float Acierto;



    void Start()
    {
        isInBox = false;
        contador = 0;
        cambio_material = 0;
        Acierto = 0;
        Renderer rend = Cubo.GetComponent<Renderer>();
        rend.material = material_1;
    }

    void Update()
    {
        if (isInBox)
        {
            //Debug.Log("Found in box!");
        }
        else
        {
            //Debug.Log("Not in box!");
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wheel1") && contador1 == 0)
        {
            contador1 = 1;
        }
        if (other.CompareTag("Wheel2") && contador2 == 0)
        {
            contador2 = 1;
        }
        if (other.CompareTag("Wheel3") && contador3 == 0)
        {
            contador3 = 1;
        }
        if (other.CompareTag("Wheel4") && contador4 == 0)
        {
            contador4 = 1;
        }

        contador = contador1 + contador2 + contador3 + contador4;
        Renderer rend = Cubo.GetComponent<Renderer>();
        if (contador == 4 && cambio_material == 0){
            //rend.material = material_2;
            isInBox = true;          
            rend.material = material_2;
            cambio_material = 1;
            Acierto = 1;
            
                
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wheel1") && contador1 == 1)
        {
            contador1 = 0;
        }
        if (other.CompareTag("Wheel2") && contador2 == 1)
        {
            contador2 = 0;
        }
        if (other.CompareTag("Wheel3") && contador3 == 1)
        {
            contador3 = 0;
        }
        if (other.CompareTag("Wheel4") && contador4 == 1)
        {
            contador4 = 0;
        }

        //contador = contador1 + contador2 + contador3 + contador4;
        //Renderer rend = Cubo.GetComponent<Renderer>();
        //if (contador != 0)
        //{
        //    rend.material = material_1;
        //    isInBox = false;
        //}
    }
}
