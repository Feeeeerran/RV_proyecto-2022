//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
//{
//    public float velocidad = 30f;
//    public float lecturaEjeZ;
//    public Vector3 movimientoZ;
//    public float lecturaEjeX;
//    public Vector3 movimientoX;

    //--------------------------------- CONTROLADOR POR INCREMENTO DE POSICIÓN --------------------------------- 
    //Este tiene problemas si el objeto está rotado
    //void Update()
    //{
    //    //MOVIMIENTO HACIA ADELANTE (EJE Z)
    //    lecturaEjeZ = Input.GetAxis("Vertical"); //Unity asocia a "Vertical" las flechas para arriba y para abajo y las letras "W" y "S"
    //    movimeintoZ = Vector3.forward * lecturaEjeZ * velocidad * Time.deltaTime; //forward es un vector con componentes [0, 0, 1] es decir que aplica un movimiento hacia adelante o hacia atrás
    //    transform.position = transfomr.position + movimientoZ;

    //    //MOVIMIENTO HACIA LOS COSTADOS (EJE X)
    //    lecturaEjeX = Input.GetAxis("Horizontal"); //Unity asocia a "Horizontal" las flechas derecha e izquierda abajo y las letras "A" y "D"
    //    movimeintoX = Vector3.right * lecturaEjeX * velocidad * Time.deltaTime; //right es un vector con componentes [1, 0, 0] es decir que aplica un movimiento hacia derecha o izquierda
    //    transform.position = transfomr.position + movimientoX;
    //}


    //-------------------------------- CONTROLADOR POR MODIFICACIÓN DE TRANSFORM -------------------------------
//    void Update()
//    {
//        //MOVIMIENTO HACIA ADELANTE(EJE Z)
//        lecturaEjeZ = Input.GetAxis("Vertical"); //Unity asocia a "Vertical" las flechas para arriba y para abajo y las letras "W" y "S"
//        movimeintoZ = Vector3.forward * lecturaEjeZ * velocidad * Time.deltaTime; //forward es un vector con componentes [0, 0, 1] es decir que aplica un movimiento hacia adelante o hacia atrás
//        transform.Translate(movimientoZ);  //Respecto al anterior esta es la línea que cambia

//        MOVIMIENTO HACIA LOS COSTADOS(EJE X)
//        lecturaEjeX = Input.GetAxis("Horizontal"); //Unity asocia a "Horizontal" las flechas derecha e izquierda abajo y las letras "A" y "D"
//        movimeintoX = Vector3.right * lecturaEjeX * velocidad * Time.deltaTime; //right es un vector con componentes [1, 0, 0] es decir que aplica un movimiento hacia derecha o izquierda
//        transform.Translate(movimientoX);
//    }
//}
