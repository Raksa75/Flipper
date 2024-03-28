using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence à la balle à suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra
    public float cameraDistance = 1f;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, cameraDistance);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
