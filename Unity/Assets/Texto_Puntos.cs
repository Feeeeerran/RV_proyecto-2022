using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Texto_Puntos : MonoBehaviour
{
    public GameObject Canva_Puntos;
    public GameObject Canva_Puntos2;
    // Start is called before the first frame update
    void Start()
    {
        Canva_Puntos.SetActive(false);
        Canva_Puntos2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Canva_Puntos.SetActive(true);
            Canva_Puntos2.SetActive(true);
        }
        
    }
}
