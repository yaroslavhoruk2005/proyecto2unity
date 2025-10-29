using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class BanderaWin : MonoBehaviour
{
    public TMP_Text mensajeWin;
    public float duracionMensaje = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(FakeWin());
        }
    }

    private IEnumerator FakeWin()
    {
        mensajeWin.text = "TE LA COMISTE \n ZOI MU GRAZIOSO";
        mensajeWin.gameObject.SetActive(true);

        yield return new WaitForSeconds(duracionMensaje);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

