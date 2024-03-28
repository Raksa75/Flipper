using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // R�f�rence � la balle � suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la cam�ra
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
