using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public GameObject txt_error; // Objeto del texto de error
    public TMP_InputField inp_user; // Objeto del input de usuario
    public TMP_InputField inp_pass; // Objeto del input de contraseña
    public Button btn_login; // Objeto del boton de login
    public Toggle tog_remember; // Objeto del toggle de recordar usuario

    private string _user = "Isra"; // Usuario
    private string _pass = "123456"; // Contraseña

    void Start()
    {
        if(PlayerPrefs.HasKey("user")) // Si existe la clave "user" en el registro
        {
            inp_user.text = PlayerPrefs.GetString("user"); // Cargamos el usuario del registro
            tog_remember.isOn = true; // Activamos el toggle
        }
        else // Si no existe la clave "user" en el registro
        {
            tog_remember.isOn = false; // Desactivamos el toggle
        }
    }

    public void CheckLogin() // Funcion para comprobar el login
    {
        if(!string.IsNullOrEmpty(inp_user.text) && !string.IsNullOrEmpty(inp_pass.text)) // Si los campos no estan vacios
        {
            if(inp_user.text == _user && inp_pass.text == _pass) // Si el usuario y la contraseña son correctos
            {
                btn_login.interactable = true; // Activamos el boton de login
                txt_error.SetActive(false); // Desactivamos el texto de error
                Debug.Log("Login Correcto"); // Mostramos un mensaje en la consola
            }
            else // Si el usuario y la contraseña son incorrectos
            {
                btn_login.interactable = false; // Desactivamos el boton de login
                txt_error.SetActive(true); // Activamos el texto de error
                Debug.Log("Login Incorrecto"); // Mostramos un mensaje en la consola
            }
        }  
    }

    public void Login(string level) //Funcion a llamar cuando se clickea el boton de login
    {
        if (tog_remember.isOn) // Si el toggle esta activado
        {
            PlayerPrefs.SetString("user", inp_user.text); // Guardamos el usuario en el registro
        }
        else // Si el toggle esta desactivado
        {
            PlayerPrefs.DeleteKey("user"); // Borramos el usuario del registro
        }
        SceneManager.LoadScene(level, LoadSceneMode.Single); // Cargamos la escena de juego
    }
}
