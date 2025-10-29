using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoNumeroNaranjas;
    public TMP_Text textoNumeroIchigos;

    private int puntosNaranjas;
    private int puntosIchigos;

    void Start()
    {
        puntosNaranjas = 0;
        puntosIchigos = 0;
        textoNumeroNaranjas.text = "0";
        textoNumeroIchigos.text = "0";
    }

    public void SumarNaranja()
    {
        puntosNaranjas++;
        textoNumeroNaranjas.text = puntosNaranjas.ToString();
    }

    public void SumarIchigo()
    {
        puntosIchigos++;
        textoNumeroIchigos.text = puntosIchigos.ToString();
    }
}
