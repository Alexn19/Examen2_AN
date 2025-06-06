using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.UI;
using UnityEngine.SceneManagement;

public class InicioGamejolt : MonoBehaviour
{
    void Start()
    {
        GameJoltUI.Instance.ShowSignIn((success) =>
        {
            if (success)
            {
                SceneManager.LoadScene("Menu");
                Trophies.Unlock(270082);

            }
            else
            {
                Debug.Log("Error");
            }
        });
    }
}
