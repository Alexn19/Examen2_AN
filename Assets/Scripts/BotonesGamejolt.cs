using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameJolt.UI;

public class BotonesGamejolt : MonoBehaviour
{
    [SerializeField] private Button botonTrofeos;
    [SerializeField] private Button botonRanking;

    public void Awake()
    {
        botonTrofeos.onClick.AddListener(() =>
        {
            GameJoltUI.Instance.ShowTrophies();
        });
        botonRanking.onClick.AddListener(() =>
        {
            GameJoltUI.Instance.ShowLeaderboards();
        });
    }

}
