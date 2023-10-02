using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Libreria para usar los botones
using TMPro; // Libreria para usar los textos
using UnityEngine.SceneManagement; // Libreria para usar los SceneManager

public class GameControllerH : MonoBehaviour
{
    public TMP_Text txt_clickCounter; // Texto que muestra el numero de clicks
    public TMP_Text txt_time; // Texto que muestra el tiempo
    public TMP_Text txt_record; // Texto que muestra el record
    public TMP_Text txt_info; // Texto que muestra la informacion
    public Button btn_click; // Boton de click
    public Button btn_reset; // Boton de reset
    public Button btn_exit; // Boton de exit
    public GameObject btn_resetObj; // Objeto del boton de reset
    public GameObject btn_clickObj; // Objeto del boton de click
    private int clicks; // Numero de clicks
    private float time = 10; // Tiempo de juego



    // Start is called before the first frame update
    void Start()
    {   
        txt_info.text =  ""; // Inicializamos el texto de info  en vacio
        clicks = 0; // Inicializamos el numero de clicks en 0
        txt_record.text = "Record: " + PlayerPrefs.GetInt("recordH").ToString(); // Obtenemos el record guardado en el dispositivo
        txt_clickCounter.text = clicks.ToString(); // Inicializamos el texto de clicks en 0
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0) // Si el tiempo es mayor a 0, se resta el tiempo
        {
        time -= Time.deltaTime; // Se resta el tiempo
        txt_time.text = time.ToString("F2"); // Se actualiza el texto del tiempo
        }
        else // Si el tiempo es menor o igual a 0
        {
            txt_time.text = "0.00";  // Se actualiza el texto del tiempo
            btn_clickObj.SetActive(false); // Se desactiva el boton de click
            btn_resetObj.SetActive(true); // Se activa el boton de reset
            if(clicks > PlayerPrefs.GetInt("recordH")) // Si el numero de clicks es mayor al record guardado
            {
                txt_info.text =  "Nuevo record"; // Se muestra el mensaje de nuevo record
                PlayerPrefs.SetInt("recordH", clicks); // Se guarda el nuevo record
                txt_record.text = "Record: " + PlayerPrefs.GetInt("recordH").ToString(); // Se actualiza el texto del record
            }
            else // Si el numero de clicks es menor al record guardado, se muestra el mensaje de que no se supero el record
            {
                if(clicks < PlayerPrefs.GetInt("recordH")) // Si el numero de clicks es menor al record guardado
                {
                    txt_info.text = "No superaste tu record"; // Se muestra el mensaje de que no se supero el record
                }
            }
        }
    }

    public void Click() // Funcion que se ejecuta al hacer click en el boton de click
    {
        clicks++; // Se aumenta el numero de clicks
        txt_clickCounter.text = clicks.ToString(); // Se actualiza el texto de clicks
        
    }

    public void Reset() // Funcion que se ejecuta al hacer click en el boton de reset
    {
        txt_info.text = ""; // Se inicializa el texto de info en vacio
        clicks = 0; // Se inicializa el numero de clicks en 0 
        txt_clickCounter.text = clicks.ToString(); // Se actualiza el texto de clicks
        time = 10; // Se inicializa el tiempo en 10
        btn_click.interactable = true; // Se activa el boton de click
        btn_resetObj.SetActive(false); // Se desactiva el boton de reset
        btn_clickObj.SetActive(true); // Se activa el boton de click
    }

    public void Exit() // Funcion que se ejecuta al hacer click en el boton de exit
    {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single); // Se carga la escena de seleccion de nivel
    }
}
