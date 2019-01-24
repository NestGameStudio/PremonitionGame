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
            case MouseState.OnPrompt:
                Cursor.lockState = CursorLockMode.None;
                this.transform.position = Input.mousePosition;
                // atualiza a posicao do cursor de acordo com o movimento e atualiza o dialogo em destaque
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
