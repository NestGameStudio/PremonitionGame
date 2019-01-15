using UnityEngine;
using UnityEngine.UI;

public enum MouseState {
    OnAction,
    Default
}

[RequireComponent(typeof(Image))]
public class CursorBehaviour: MonoBehaviour {

    [SerializeField]
    private Sprite CursorImage;
    [SerializeField]
    private Sprite ClickingImage;

    private PlayerInteractivity interact;

    public MouseState currentMouseState = MouseState.Default;

    void Start() {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<PlayerInteractivity>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.GetComponent<Image>().sprite = ClickingImage;

            if (currentMouseState == MouseState.Default) {
                if (interact != null) {
                    interact.CheckIfHitObject();
                }
            }
            
        } else if (Input.GetMouseButtonUp(0)) {
            this.GetComponent<Image>().sprite = CursorImage;
        }

        switch (currentMouseState) {
            case MouseState.OnAction:
                this.GetComponent<Image>().enabled = false;
                break;
            default:
                this.GetComponent<Image>().enabled = true;
                break;
        }

    }

}
