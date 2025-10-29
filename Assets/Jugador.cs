using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    [Header("----------Movimiento----------")]
    public float velocidad = 5f;
    private float movimientoX;
    private Rigidbody2D rb2d;

    [Header("----------Salto----------")]
    public float fuerzaSalto = 7f;
    private bool enSuelo = false;

    [Header("----------Deteccion de suelo----------")]
    public Transform comprobadorSuelo;
    public float radioSuelo = 0.1f;
    public LayerMask capaSuelo;

    [Header("----------Animaciones----------")]
    private Animator animator;

    [Header("----------Audio----------")]
    public AudioSource audioSource;     
    public AudioClip musicaFondo;      
    public AudioClip getNaranjas;       
    public AudioClip getIchigos;        
    public AudioClip sonidoMuerto;     

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (audioSource != null && musicaFondo != null)
        {
            audioSource.clip = musicaFondo;
            audioSource.loop = true;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }
    }

    void Update()
    {

        rb2d.linearVelocity = new Vector2(movimientoX * velocidad, rb2d.linearVelocity.y);

        if (comprobadorSuelo != null)
        {
            enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioSuelo, capaSuelo);
        }

        animator.SetBool("estaSaltando", !enSuelo);
        animator.SetBool("estaCorriendo", movimientoX != 0 && enSuelo);
    }

    private void OnMove(InputValue inputMovimiento)
    {
        movimientoX = inputMovimiento.Get<Vector2>().x;

        if (movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
        }
    }

    private void OnJump(InputValue inputSalto)
    {
        if (enSuelo)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
        }
    }

    void OnDrawGizmos()
    {
        if (comprobadorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(comprobadorSuelo.position, radioSuelo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ESTO ES PARA LAS NARANJAS
        if (collision.CompareTag("Naranja"))
        {
            if (audioSource != null && getNaranjas != null)
                audioSource.PlayOneShot(getNaranjas);

            FindAnyObjectByType<GameManager>().SumarNaranja();
            Destroy(collision.gameObject);
        }

        // ESTO ES PARA LOS ICHIGOS
        if (collision.CompareTag("Ichigo"))
        {
            if (audioSource != null && getIchigos != null)
                audioSource.PlayOneShot(getIchigos);

            FindAnyObjectByType<GameManager>().SumarIchigo();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SueloMuerte") || collision.CompareTag("Enemigo"))
        {
            if (sonidoMuerto != null)
                AudioSource.PlayClipAtPoint(sonidoMuerto, Camera.main.transform.position);

            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
