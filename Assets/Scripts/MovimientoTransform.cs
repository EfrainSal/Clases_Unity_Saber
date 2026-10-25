using UnityEngine;

public class MovimientoTransform : MonoBehaviour
{
    public float velocidad = 10f;

    void Update()
    {
        float movimiento = Input.GetAxisRaw("Horizontal");

        transform.Translate(
            Vector3.right * movimiento * velocidad * Time.deltaTime
        );
    }
}
