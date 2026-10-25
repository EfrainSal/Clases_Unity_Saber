using UnityEngine;

public class ControlPlataforma : MonoBehaviour
{
   public float speed = 12f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Obtener entrada del teclado (A/D o Flechas Izquierda/Derecha)
        float moveInput = Input.GetAxis("Horizontal");

        // Controlar la velocidad de la paleta mediante linearVelocity en el eje X
        rb.linearVelocity = new Vector2(moveInput * speed, 0f);
    }
}
