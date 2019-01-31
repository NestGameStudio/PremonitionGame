using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {

    [SerializeField]    // SerialiazeField make it show up in the inspector even though it is a private variable
    private float speed = 5f;
    [SerializeField]
    private float mouseSensitivity = 10f;

    private PlayerMovement movement;

    public Animator PlayerAnimator;

    private void Start() {

        // Don't need to check if there is a playermovement because there's a requirement
        movement = GetComponent<PlayerMovement>();
    }


    private void Update() {

        // 1 - Calculate moment velocity as a 3D vector
            // Raw don't let unity make their smoothing and processess
        float horizontalMovement = Input.GetAxisRaw("Horizontal"); // X axis
        float verticalMovement = Input.GetAxisRaw("Vertical"); // Z axis

            // transform gets the local direction while Vector3.Right gets the global direction
        Vector3 horizontalDirection = transform.right * horizontalMovement; // (x,0,0)  x = from -1 to 1
        Vector3 verticalDirection = transform.forward * verticalMovement; // (0,0,z)  z = from -1 to 1

        // - Final movement vector
            // Normalized make the vector goes to his canonical version
        Vector3 velocity = (horizontalDirection + verticalDirection).normalized * speed;

        // - Apply movement
        movement.Move(velocity);


        // 2 - calculate rotation as a 3D Vector (turning around)
        float rotationDirection = Input.GetAxisRaw("Mouse X"); // Y axis

        // - Want to apply the rotation to the camera, not the player, só ir won't mess up with the translation
        Vector3 rotation = new Vector3(0f, rotationDirection, 0f) * (mouseSensitivity*50) * Time.deltaTime;

        // - Apply rotation
        movement.Rotate(rotation);


        // 3 - calculate camera rotation as a 3D Vector (turning around)
        float cameraRotationDirection = Input.GetAxisRaw("Mouse Y"); // X axis

        Vector3 cameraRotation = new Vector3(cameraRotationDirection, 0f, 0f) * (mouseSensitivity*50) * Time.deltaTime;

        // - Apply camera rotation
        movement.RotateCamera(cameraRotation);

        if (Input.GetButton("Fire2")){
            PlayerAnimator.SetBool("ArmUp", true);
        }else
        {
            PlayerAnimator.SetBool("ArmUp", false);
        }
    }

}
