using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJolt.API;

public class Escenas : MonoBehaviour
{
    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego");
        Trophies.Unlock(270083);
    }
}
