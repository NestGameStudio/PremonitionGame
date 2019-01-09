using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement: MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Run avery physics iteration
    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }


    // Gets a movement vector
    public void Move(Vector3 _velocity) {
        velocity = _velocity;
    }

    // Gets a rotation vector
    public void Rotate(Vector3 _rotation) {
        rotation = _rotation;
    }

    // Gets a rotation vector
    public void RotateCamera(Vector3 _cameraRotation) {
        cameraRotation = _cameraRotation;
    }

    // Perform movement based on velocity variable
    private void PerformMovement() {

        if (velocity != Vector3.zero) {

            // different from transform.MovePosition because if it's something on they way we are moving it will not transpass - does the physics checks
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

    }

    // Perform rotation based on mouseSentivity variable
    private void PerformRotation() {

        // Quaternions fazem a rotação então não são Vector3's - Quaternion.Euler transforms that Vector3 rotation into a Quaternion
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null) {
            cam.transform.Rotate(-cameraRotation);
        }

    }


}
