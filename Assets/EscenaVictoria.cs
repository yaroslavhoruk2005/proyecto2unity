using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaVictoria : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadMainMenu", 3);
    }

   public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
