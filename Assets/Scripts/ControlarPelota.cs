using UnityEngine;

public class ControlarPelota : MonoBehaviour
{
   public float initialSpeed = 10f;
    public float minYLimit = -6f; // Límite en Y para saber si cayó por debajo de la paleta
    private Rigidbody2D rb;
    private bool isStarted = false;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Guarda la posición inicial (sobre la paleta)
    }

    void Update()
    {
        // Lanzar la pelota al presionar Espacio si aún no está en juego
        if (!isStarted && Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }

        // Si la pelota cae por debajo del límite de la paleta, reiniciar
        if (isStarted && transform.position.y < minYLimit)
        {
            ResetBall();
        }
    }

    void FixedUpdate()
    {
        if (isStarted)
        {
            // 1. Mantener la velocidad constante
            Vector2 currentVelocity = rb.linearVelocity;
            
            // 2. Anti-bloqueo: Si la pelota se queda casi horizontal (vy muy baja) o casi vertical (vx muy baja)
            if (Mathf.Abs(currentVelocity.x) < 1.5f)
            {
                // Forzar un pequeño desvío en X para que no rebote plano
                float randomDirection = Random.value > 0.5f ? 1f : -1f;
                currentVelocity.x = 3f * randomDirection;
            }
            if (Mathf.Abs(currentVelocity.y) < 1.5f)
            {
                // Forzar un pequeño desvío en Y
                float randomDirection = Random.value > 0.5f ? 1f : -1f;
                currentVelocity.y = 3f * randomDirection;
            }

            // Aplicar la velocidad corregida y normalizada
            rb.linearVelocity = currentVelocity.normalized * initialSpeed;
        }
    }

    void LaunchBall()
    {
        isStarted = true;
        transform.SetParent(null); // Despegar de la paleta
        
        // Dar un impulso inicial aleatorio hacia arriba
        float randomX = Random.Range(-0.5f, 0.5f);
        Vector2 forceDir = new Vector2(randomX, 1f).normalized;
        rb.linearVelocity = forceDir * initialSpeed;
    }

    void ResetBall()
    {
        isStarted = false;
        rb.linearVelocity = Vector2.zero;
        
        // Volver a colocar la pelota en su posición inicial (puedes ajustarla al objeto de la paleta si quieres que la siga)
        transform.position = initialPosition;
        // Opcional: volver a emparentarla a la paleta si quieres que se mueva con ella antes de disparar:
        // transform.SetParent(GameObject.Find("Paddle").transform);
    }
}
