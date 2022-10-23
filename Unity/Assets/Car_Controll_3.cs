using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controll_3 : MonoBehaviour
{
    public Rigidbody _rb;
    public float velocidad = 30f;
    public float lecturaEje;
    public Vector3 movimiento;

    public float giro = 180;
    public Vector3 torsion;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        lecturaEje = Input.GetAxis("Vertical");
        movimiento = transform.forward * lecturaEje * velocidad;

        float velocidadZ = _rb.velocity.z;
        _rb.velocity = movimiento;
        _rb.velocity = new Vector3(_rb.velocity.x, 0, velocidadZ);

        lecturaEje = Input.GetAxis("Horizontal");
        torsion = Vector3.up * lecturaEje * giro * Time.deltaTime;

        transform.Rotate(torsion);
    }
}
