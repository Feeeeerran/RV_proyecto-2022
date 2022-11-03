
//-----------------------------------------------------------------------//
//---------------------------------USING---------------------------------//
//-----------------------------------------------------------------------//
using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//-----------------------------------------------------------------------//



//-----------------------------------------------------------------------//
//---------------------------------EJES----------------------------------//
//-----------------------------------------------------------------------//
public enum Axel
{
    Front,
    Rear
}
//-----------------------------------------------------------------------//



//-----------------------------------------------------------------------//
//--------------------------------WHEELS---------------------------------//
//-----------------------------------------------------------------------//

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;

    public Axel axel;
}
//-----------------------------------------------------------------------//



//-----------------------------------------------------------------------//
//----------------------------CAR CONTROLLER-----------------------------//
//-----------------------------------------------------------------------//
public class Car_Controller : MonoBehaviour
{

    //****************************Car Variables****************************//
    [SerializeField]
    private float maxAcceleration = 20.0f; //Aceleración

    [SerializeField]
    private float turnSensitivity = 1.0f;  //Sensibilidad de giro

    [SerializeField]
    private float maxSteerAngle = 45.0f;   //Ángulo máximo de giro

    [SerializeField]
    private List<Wheel> wheels;            //4 ruedas

    public float inputX, inputY;           //Variables para identificar el giro

    public float derecha = 0, izquierda = 0;//Se usa para animar el volante

    private bool brake;
    public float Brake = 10000;            //Freno de mano

    public Rigidbody _rb;

    public WheelCollider frontDriveW;
    public WheelCollider frontPassengerW;
    public WheelCollider rearDriveW;
    public WheelCollider rearPassengerW;

    
    public GameObject Steering_wheel;     //Volante
    //*********************************************************************//



    //*******************************PUNTAJE******************************//
    public TextMeshProUGUI texto_marcador;

    public float marcador;
    public float contador_Valla1;
    private float contador_Valla2;

    private float contador_Cono1;
    private float contador_Cono2;
    private float contador_Cono3;
    private float contador_Cono4;
    private float contador_Cono5;

    private float contador_Barrera1;
    private float contador_Barrera2;

    private float contador_Conos;
    //*********************************************************************//



    //****************************Pantalla Pausa***************************//
    [SerializeField] GameObject pantallaPausa;
    public GameObject Failed_Menu;
    //*********************************************************************//



    //********************************Start*******************************//
    private void Start()
    {
        marcador = 0;
        contador_Valla1 = 0;
        contador_Valla2 = 0;

        contador_Cono1 = 0;
        contador_Cono2 = 0;
        contador_Cono3 = 0;
        contador_Cono4 = 0;
        contador_Cono5 = 0;

        contador_Barrera1 = 0;
        contador_Barrera2 = 0;

        contador_Conos = 0;

        texto_marcador.text = "Mistakes: " + marcador;
}
    //*********************************************************************//



    //********************************Update*******************************//
    private void Update()
    {
        AnimateWheels();
        GetInputs();
    }
    //*********************************************************************//



    //*****************************FixedUpdate****************************//
    private void FixedUpdate() //Es recomendado que el cálculo de las físicas se haga acá
    {
        Move();
        Turn();
    }
    //*********************************************************************//



    //***************************Inputs para Ejes**************************//
    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        brake = Input.GetButton("Jump");
    }
    //*********************************************************************//



    //******************************Movimiento*****************************//
    private void Move()
    {
        
        if (inputX > 0) //Giro derecha
        {
            //wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
            frontDriveW.motorTorque = inputY * maxAcceleration * 50000 * Time.deltaTime;
            
            frontPassengerW.motorTorque = inputY * maxAcceleration * 0 * Time.deltaTime;

            rearDriveW.brakeTorque = Brake;
            rearPassengerW.brakeTorque = Brake;

        }
        if (inputX < 0) //Giro izquierda
        {
            //wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
            frontDriveW.motorTorque = inputY * maxAcceleration * 0 * Time.deltaTime;
            frontPassengerW.motorTorque = inputY * maxAcceleration * 50000 * Time.deltaTime;

            rearDriveW.brakeTorque = Brake;
            rearPassengerW.brakeTorque = Brake;
        }
        else
        {
            frontDriveW.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
            frontPassengerW.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;

            rearDriveW.brakeTorque = inputY*Brake;
            rearPassengerW.brakeTorque = inputY*Brake;
        }

        foreach (var wheel in wheels) { 

                if (brake == true)
            {

                wheel.collider.brakeTorque = Brake*10000;
                //frontPassengerW.brakeTorque = Brake * 10000;
                //element.rightWheel.brakeTorque = 1000;

            }

            if (brake == false)
            {

                wheel.collider.brakeTorque = 0;
                //element.rightWheel.brakeTorque = 0;

            }

            if (inputY == 0)
            {
                wheel.collider.brakeTorque = Brake*10000;
            }
        }
    }
    //*********************************************************************//



    //********************************Doblar*******************************//
    private void Turn()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle,0.5f);
                
            }
        }
        
    }
    //*********************************************************************//



    //*********************Animación Ruedas y Volante*********************//
    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 rott;
            Vector3 _pos;


            //__________________________RUEDAS__________________________//
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
            //__________________________________________________________//


            //_________________________VOLANTE_________________________//
            if (inputX > 0 && derecha == 0)
            {
                if (izquierda == 1)
                {
                    Steering_wheel.transform.Rotate(90 * Vector3.up, Space.Self);
                    izquierda = 0;
                    derecha = 1;
                }
                else
                {
                    Steering_wheel.transform.Rotate(45 * Vector3.up, Space.Self);
                    derecha = 1;
                }        
            }
            if (inputX < 0 && izquierda == 0)
            {
                if (derecha == 1)
                {
                    Steering_wheel.transform.Rotate(-90 * Vector3.up, Space.Self);
                    derecha = 0;
                    izquierda = 1;
                }
                else
                {
                    Steering_wheel.transform.Rotate(-45 * Vector3.up, Space.Self);
                    izquierda = 1;
                }
            }
            if (inputX == 0 )
            {
                if (derecha == 1)
                {
                    Steering_wheel.transform.Rotate(-45 * Vector3.up, Space.Self);
                    derecha = 0;               
                }
                if (izquierda == 1)
                {
                    Steering_wheel.transform.Rotate(+45 * Vector3.up, Space.Self);
                    izquierda = 0;
                }
            }
        }
        //__________________________________________________________//

    }
    //*********************************************************************//



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Valla1") && contador_Valla1 == 0)
        {
            marcador = marcador + 1;
            contador_Valla1 = 1;
        }


        if (collision.gameObject.CompareTag("Valla2") && contador_Valla2 == 0)
        {
            marcador = marcador + 1;
            contador_Valla2 = 1;
        }


        if (collision.gameObject.CompareTag("Cono1") && contador_Cono1 == 0)
        {
            marcador = marcador + 1;
            contador_Cono1 = 1;
        }


        if (collision.gameObject.CompareTag("Cono2") && contador_Cono2 == 0)
        {
            marcador = marcador + 1;
            contador_Cono2 = 1;
        }


        if (collision.gameObject.CompareTag("Cono3") && contador_Cono3 == 0)
        {
            marcador = marcador + 1;
            contador_Cono3 = 1;
        }


        if (collision.gameObject.CompareTag("Cono4") && contador_Cono4 == 0)
        {
            marcador = marcador + 1;
            contador_Cono4 = 1;
        }


        if (collision.gameObject.CompareTag("Cono5") && contador_Cono5 == 0)
        {
            marcador = marcador + 1;
            contador_Cono5 = 1;
        }


        if (collision.gameObject.CompareTag("Barrera1") && contador_Barrera1 == 0)
        {
            marcador = marcador + 1;
            contador_Barrera1 = 1;
        }


        if (collision.gameObject.CompareTag("Barrera2") && contador_Barrera2 == 0)
        {
            marcador = marcador + 1;
            contador_Barrera2 = 1;
        }


        if (collision.gameObject.CompareTag("Conos") && contador_Conos == 0)
        {
            marcador = marcador + 1;
            contador_Conos = 1;
        }

        texto_marcador.text = "Mistakes: " + marcador;

        //if (marcador >= 3)
        //{
        //    Failed_Menu.SetActive(true);
        //    Time.timeScale = 0f;
        //}
    }

    public void Reiniciar_Juego()
    {
        Failed_Menu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
