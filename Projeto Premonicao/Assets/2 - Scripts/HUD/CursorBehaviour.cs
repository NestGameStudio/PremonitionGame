using UnityEngine;
using UnityEngine.UI;

public enum MouseState {
    OnPrompt,
    OnDialog,
    Default
}

[RequireComponent(typeof(Image))]
public class CursorBehaviour: MonoBehaviour {

    [SerializeField]
    private Sprite CursorImage;
    [SerializeField]
    private Sprite ClickingImage;
    [SerializeField]
    private Sprite InteractiveImage;

    private PlayerInteractivity interact;

    public MouseState currentMouseState;

    void Start() {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<PlayerInteractivity>();

        currentMouseState = MouseState.Default;

    }

    void Update()
    {
        if (interact.CheckIfHitObject()) {
            if (!DialogueManager.Instance.DialogueSelection && !DialogueManager.Instance.ConversationStarted) {
                this.GetComponent<Image>().sprite = InteractiveImage;
            }
        } else {
            this.GetComponent<Image>().sprite = CursorImage;
        }

        if (Input.GetMouseButtonDown(0)) {
            this.GetComponent<Image>().sprite = ClickingImage;

            if (currentMouseState == MouseState.Default) {
                if (interact != null) {
                    interact.TriggerActionOnGameObject();
                }
            }
            
        } else if (Input.GetMouseButtonUp(0)) {
            this.GetComponent<Image>().sprite = CursorImage;
        }

        switch (currentMouseState) {
            case MouseState.OnPrompt:
                Cursor.lockState = CursorLockMode.None;
                this.transform.position = Input.mousePosition;
                break;

            case MouseState.OnDialog:
                this.GetComponent<Image>().enabled = false;
                break;

            default:
                this.GetComponent<Image>().enabled = true;
                this.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }

    }

}
