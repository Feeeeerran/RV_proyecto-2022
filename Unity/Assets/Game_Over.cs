using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    public Car_Controller C;

    public GameObject Game_Over_Menu;
    //public static bool GameIsPaused = false;

    public float Mistakes = 0;
    public float contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        Mistakes = 0;
        contador = 0;
        Game_Over_Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        Mistakes = C.marcador;
        if (Mistakes == 3)
        {
            //Game_Over_Menu.SetActive(true);
            Game_Over_Menu.SetActive(true);
            Time.timeScale = 0f;
            
            //contador = 1;
        }
        
    }

    void Show()
    {
        Game_Over_Menu.SetActive(true);
        //Time.timeScale = 0f;
        
    }
}
