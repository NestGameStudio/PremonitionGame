using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class InventoryManager: MonoBehaviour {

    private static InventoryManager instance;

    public int MaxNumOfObjects;
    public GameObject HUDInventoryObjects;
    public GameObject ItemDetail;

    private List<Object> ObjectsInInventory = new List<Object>();

    private int currentItem = 0;

    private bool isLookingItem = false;

    public static InventoryManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
    }

    // lista de itens no inventário, a seleção deles faz aparecer em fade-in o nome e descrição que desaparece depois de um tempo e a seleção dos itens roda conforme o mouse scroll

    private void Update() {

        if (!Keypad.Instance.KeypadOn && !DialogueManager.Instance.DialogueSelection) {

            if (Input.GetAxis("Mouse ScrollWheel") > 0f & !isLookingItem) {

                if (currentItem < ObjectsInInventory.Count - 1) {
                    currentItem++;
                    HUDInventoryObjects.transform.GetChild(currentItem - 1).GetComponent<Image>().CrossFadeAlpha(0.5f, 0.3f, false);
                }

                HUDInventoryObjects.transform.GetChild(currentItem).GetComponent<Image>().CrossFadeAlpha(1f, 0.3f, false);
                StartCoroutine(ShowName(HUDInventoryObjects.transform.GetChild(currentItem).transform.GetChild(0).gameObject, HUDInventoryObjects.transform.GetChild(currentItem).transform.GetChild(1).gameObject));


            } else if (Input.GetAxis("Mouse ScrollWheel") < 0f && !isLookingItem) {

                if (currentItem > 0) {
                    currentItem--;
                    HUDInventoryObjects.transform.GetChild(currentItem + 1).GetComponent<Image>().CrossFadeAlpha(0.5f, 0.3f, false);
                }

                HUDInventoryObjects.transform.GetChild(currentItem).GetComponent<Image>().CrossFadeAlpha(1f, 0.3f, false);

                StartCoroutine(ShowName(HUDInventoryObjects.transform.GetChild(currentItem).transform.GetChild(0).gameObject, HUDInventoryObjects.transform.GetChild(currentItem).transform.GetChild(1).gameObject));
            }

            if (Input.GetKey(KeyCode.Space) && ObjectsInInventory.Count > 0) {

                Debug.Log(currentItem);

                ItemDetail.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = ObjectsInInventory[currentItem].HUDSprite;
                ItemDetail.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ObjectsInInventory[currentItem].Name;
                ItemDetail.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = ObjectsInInventory[currentItem].Description;

                ItemDetail.SetActiveRecursively(true);

                isLookingItem = true;
            } else {

                ItemDetail.SetActiveRecursively(false);

                isLookingItem = false;
            }

        }

    }

    IEnumerator ShowName(GameObject name, GameObject description) {

        name.GetComponent<Text>().CrossFadeAlpha(1f, 0.8f, false);
        description.GetComponent<Text>().CrossFadeAlpha(1f, 0.8f, false);

        yield return new WaitForSeconds(1f);

        name.GetComponent<Text>().CrossFadeAlpha(0f, 0.8f, false);
        description.GetComponent<Text>().CrossFadeAlpha(0f, 0.8f, false);

    }

    public void putIntemInInventory(Object interactiveObject) {

        // Add item in Inventory if it's not on it's limit
        if (ObjectsInInventory.Count < MaxNumOfObjects) {
            ObjectsInInventory.Add(interactiveObject);

            if (HUDInventoryObjects != null) {

                foreach (Transform inventoryObject in HUDInventoryObjects.GetComponentsInChildren<Transform>(true)) {
                    
                    if (!inventoryObject.gameObject.activeSelf) {
                        inventoryObject.GetComponent<Image>().sprite = interactiveObject.HUDSprite;
                        inventoryObject.GetComponent<Image>().useSpriteMesh = true;
                        inventoryObject.transform.GetChild(0).GetComponent<Text>().text = interactiveObject.Name;
                        inventoryObject.transform.GetChild(1).GetComponent<Text>().text = interactiveObject.Description;

                        if (ObjectsInInventory.Count == 1) {
                            inventoryObject.GetComponent<Image>().CrossFadeAlpha(1f, 0.0f, false);
                        } else {
                            inventoryObject.GetComponent<Image>().CrossFadeAlpha(0.5f, 0.3f, false);
                        }

                        StartCoroutine(ShowName(inventoryObject.transform.GetChild(0).gameObject, inventoryObject.transform.GetChild(1).gameObject));

                        interactiveObject.Model.transform.parent.parent.gameObject.SetActive(false);
                        inventoryObject.gameObject.SetActive(true);
                        break;
                    }
                }
            }

        } else {
            Debug.Log("Atingiu o limite de objetos do inventário");
        }
    }

    public bool checkIfHaveItem(GameObject item) {

        foreach (Object itemFromInventory in ObjectsInInventory) {

            if (item.GetComponent<ActionGrabObject>().interactiveObject == itemFromInventory) {
                return true;
            }
        }

        return false;

    }

    public void removeObjectFromInventory(GameObject item) {

        foreach (Object itemFromInventory in ObjectsInInventory) {

            if (item.GetComponent<ActionGrabObject>().interactiveObject == itemFromInventory) {
                ObjectsInInventory.Remove(item.GetComponent<ActionGrabObject>().interactiveObject);

                foreach (Image inventoryObject in HUDInventoryObjects.GetComponentsInChildren<Image>(true)) {

                    if (inventoryObject.GetComponent<Image>().sprite.name == itemFromInventory.HUDSprite.name) {
                        inventoryObject.gameObject.SetActive(false);
                        break;
                    }
                }
                break;
            }
        }

    }
    
}
