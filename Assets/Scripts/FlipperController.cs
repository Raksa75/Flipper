using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public KeyCode flipperKey = KeyCode.Space; // Touche pour activer le flipper
    public float flipperAngle = 30f; // Angle de rotation du flipper
    public float flipperSpeed = 1000f; // Vitesse de rotation du flipper
    public float flipperRestitutionSpeed = 500f; // Vitesse de retour à la position d'origine

    private Quaternion initialRotation;
    private Quaternion downRotation;
    private bool flipping = false;

    void Start()
    {
        initialRotation = transform.rotation;
        downRotation = Quaternion.Euler(Vector3.back * flipperAngle);
    }

    void Update()
    {
        if (Input.GetKeyDown(flipperKey) && !flipping)
        {
            flipping = true;
            RotateFlipper();
        }
    }

    void FixedUpdate()
    {
        if (flipping)
        {
            // Calculer la rotation actuelle et la rotation finale
            Quaternion targetRotation = flipping ? downRotation : initialRotation;
            Quaternion currentRotation = transform.rotation;

            // Interpoler entre la rotation actuelle et la rotation finale
            Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, flipperSpeed * Time.fixedDeltaTime);
            transform.rotation = newRotation;

            // Si la rotation a atteint la rotation finale, arrêter le flipper
            if (Quaternion.Angle(newRotation, targetRotation) < 0.01f)
            {
                flipping = false;
            }
        }
    }

    void RotateFlipper()
    {
        flipping = true;
    }
}
