using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;



public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;

    public Axel axel;
}
public class Car_Controller : MonoBehaviour
{
    [SerializeField]
    private float maxAcceleration = 20.0f;

    [SerializeField]
    private float turnSensitivity = 1.0f;

    [SerializeField]
    private float maxSteerAngle = 45.0f;

    [SerializeField]
    private List<Wheel> wheels;

    public float inputX, inputY;

    public float derecha = 0, izquierda = 0;

    private bool brake;
    public float Brake = 10000;

    public Rigidbody _rb;

    public WheelCollider frontDriveW;
    public WheelCollider frontPassengerW;
    public WheelCollider rearDriveW;
    public WheelCollider rearPassengerW;

    
    public GameObject Steering_wheel;

    private bool isCarGrounded;
    public float alignToGroundTime;
    public LayerMask Plane;
    public float pp;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        AnimateWheels();
        GetInputs();

    }

    private void FixedUpdate() //Es recomendado que el cálculo de las físicas se haga acá
    {
        Move();
        Turn();
    }

    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        brake = Input.GetButton("Jump");
    }

    private void Move()
    {
        
        if (inputX > 0) //Giro derecha
        {
            //wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
            frontDriveW.motorTorque = inputY * maxAcceleration * 50000 * Time.deltaTime;
            
            frontPassengerW.motorTorque = inputY * maxAcceleration * 0 * Time.deltaTime;

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

            rearDriveW.brakeTorque = Brake;
            rearPassengerW.brakeTorque = Brake;
        }

        foreach (var wheel in wheels) { 

                if (brake == true)
            {

                wheel.collider.brakeTorque = Brake*10000;
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

    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 rott;

            //rott = new Vector3(-45, 0, 0);
            Vector3 _pos;

            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
            
            //Steering_wheel.transform.Rotate(45 * Vector3.up, Space.Self);
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
        
    }
}
