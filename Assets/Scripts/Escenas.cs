using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}
