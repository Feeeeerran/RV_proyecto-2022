using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Lectura_Aciertos : MonoBehaviour
{

    public TextMeshProUGUI texto_Aciertos;


    public Is_Inside f;
    public Is_Inside a;
    public Is_Inside b;
    public Is_Inside c;
    public Is_Inside d;
    public Is_Inside e;
    public Is_Inside g;

    public float Aciertos = 0;

    public GameObject Passed_Menu;
    // Start is called before the first frame update
    void Start()
    {
        
        Aciertos = 0;
        Passed_Menu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Aciertos = a.Acierto + b.Acierto + c.Acierto + d.Acierto + e.Acierto + f.Acierto + g.Acierto;

        texto_Aciertos.text = "Hits: " + Aciertos;

        if (Aciertos == 7)
        {
            Passed_Menu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Reiniciar_Juego()
    {
        Passed_Menu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
