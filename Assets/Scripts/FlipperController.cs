using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public KeyCode flipperKey = KeyCode.Space; // Touche pour activer le flipper
    public float flipperStrength = 1000f; // Force de rotation du flipper
    public float flipperReturnSpeed = 500f; // Vitesse de retour du flipper à sa position d'origine
    public float maxRotation = 30f; // Angle maximum de rotation du flipper
    public Rigidbody2D ball; // Référence à la balle

    private Quaternion initialRotation;
    private bool isFlipping = false;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Si la touche est enfoncée et le flipper n'est pas déjà en train de basculer
        if (Input.GetKeyDown(flipperKey) && !isFlipping)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Si le flipper est en train de basculer
        if (isFlipping)
        {
            // Calculer la rotation cible en fonction de l'angle maximum
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, initialRotation.eulerAngles.z + maxRotation);

            // Faire tourner le flipper vers la rotation cible
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, flipperStrength * Time.fixedDeltaTime);

            // Si le flipper a atteint l'angle maximum, arrêter de basculer
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                isFlipping = false;
            }
        }
        else
        {
            // Si le flipper n'est pas en train de basculer, le ramener à sa position d'origine
            transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, flipperReturnSpeed * Time.fixedDeltaTime);
        }
    }

    void Flip()
    {
        isFlipping = true;
    }
}
