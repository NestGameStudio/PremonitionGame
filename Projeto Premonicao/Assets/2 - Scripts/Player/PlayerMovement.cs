using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement: MonoBehaviour {

    // ------------------------- Variables ------------------------- //

    // --- Private Variables --- //
    [SerializeField] private Camera cam;
    [SerializeField] private RespawnControl Respawn;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Rigidbody rb;

    // ------------------------- Functions ------------------------- //

    // --- Public Functions --- //

    /// < Move(Vector3 _velocity): void >
    /// Gets a movement vector
    /// </Move(Vector3 _velocity): void>
    public void Move(Vector3 _velocity) {
        velocity = _velocity;
    }

    /// < Rotate(Vector3 _rotation): void >
    /// Gets a rotation vector
    /// </ Rotate(Vector3 _rotation): void >
    public void Rotate(Vector3 _rotation) {
        rotation = _rotation;
    }

    /// < RotateCamera(Vector3 _cameraRotation): void >
    /// Gets a rotation vector
    /// </ RotateCamera(Vector3 _cameraRotation): void >
    public void RotateCamera(Vector3 _cameraRotation) {

        cameraRotation = _cameraRotation;
    }

    // --- Private Functions --- //

    /// < Start(): void >
    /// get the rigidBody component from the player
    /// </ Start(): void >
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    /// < FixedUpdate(): void >
    /// Run every physics iteration
    /// </ FixedUpdate(): void >
    private void FixedUpdate() {

        if ((!DialogueManager.Instance.DialogueSelection && !DialogueManager.Instance.ConversationStarted) && !Respawn.LostGame)
        {
            PerformMovement();
            PerformRotation();
        }
    
    }

    /// < PerformMovement(): void >
    /// Perform movement based on velocity variable
    /// </ PerformMovement(): void >
    private void PerformMovement() {

        if (velocity != Vector3.zero) {

            // different from transform.MovePosition because if it's something on they way we are moving it will not transpass - does the physics checks
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

    }

    /// < PerformRotation(): void >
    /// Perform rotation based on mouseSentivity variable
    /// </ PerformRotation(): void >
    private void PerformRotation() {

        // Quaternions fazem a rotação então não são Vector3's - Quaternion.Euler transforms that Vector3 rotation into a Quaternion
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null) {

            float angle = cam.transform.localEulerAngles.x;

            angle %= 360;
            if (angle > 180) {
                angle = angle - 360;
            }
            
            // não permite que a camera faça uma rotação de 360
            if (angle - cameraRotation.x + 90 < 180 && angle - cameraRotation.x + 90 > 0) {
                 cam.transform.Rotate(-cameraRotation);
            }
        }

    }


}
