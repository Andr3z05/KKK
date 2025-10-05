using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovJugador : MonoBehaviour
{
    public float velocidad = 10f;
    public float rotacionVel = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que se caiga o rote por colisiones
    }

    void FixedUpdate()
    {
        float mover = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        float girar = Input.GetAxis("Horizontal") * rotacionVel * Time.deltaTime;

        // Movimiento hacia adelante/atrás
        Vector3 movimiento = transform.forward * mover;
        rb.MovePosition(rb.position + movimiento);

        // Rotación izquierda/derecha
        Quaternion rot = Quaternion.Euler(0f, girar, 0f);
        rb.MoveRotation(rb.rotation * rot);
    }
}
