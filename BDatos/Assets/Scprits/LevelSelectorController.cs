using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Libreria para usar los SceneManager

public class LevelSelectorController : MonoBehaviour
{
    public void LoadLevel(string level) // Funcion para cargar el nivel
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single); // Se carga el nivel
    }
}
