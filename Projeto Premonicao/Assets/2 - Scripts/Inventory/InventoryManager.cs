using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class InventoryManager: MonoBehaviour {

    private static InventoryManager instance;

    public int MaxNumOfObjects;
    public GameObject HUDInventoryObjects;

    private List<Object> ObjectsInInventory = new List<Object>();

    public static InventoryManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
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
