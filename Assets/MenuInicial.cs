using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public GameObject panelPrincipal;  
    public GameObject panelCreditos;

    public void Jugar()
    {
        SceneManager.LoadScene("ElJuego");
    }

    public void Salir()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void MostrarCreditos()
    {
        if (panelCreditos != null)
            panelCreditos.SetActive(true);

        if (panelPrincipal != null)
            panelPrincipal.SetActive(false); 
    }

    public void CerrarCreditos()
    {
        if (panelCreditos != null)
            panelCreditos.SetActive(false);

        if (panelPrincipal != null)
            panelPrincipal.SetActive(true);
    }
}
