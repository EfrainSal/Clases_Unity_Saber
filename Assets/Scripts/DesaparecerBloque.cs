using UnityEngine;

public class DesaparecerBloque : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destruir el bloque al recibir el impacto
            Destroy(gameObject);
        }
    }
}
