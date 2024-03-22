using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence à la balle à suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
