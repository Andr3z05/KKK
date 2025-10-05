using UnityEngine;

public class Camara1rapersona : MonoBehaviour
{
    public float Velocidad = 100f;

    float rotacionX = 0f; // arriba/abajo
    float rotacionY = 0f; // izquierda/derecha

    public Transform jugador;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Si te olvidas de asignar el jugador, se toma el padre automáticamente
        if (jugador == null)
            jugador = transform.parent;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Velocidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Velocidad * Time.deltaTime;

        // Movimiento vertical (arriba/abajo)
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 0f);

        // Movimiento horizontal (izquierda/derecha) con límite
        rotacionY += mouseX;
        rotacionY = Mathf.Clamp(rotacionY, -120f, 45f); // ← Aquí defines tus límites

        // Aplica las rotaciones
        transform.localRotation = Quaternion.Euler(rotacionX, rotacionY, 0f);
    }
}


