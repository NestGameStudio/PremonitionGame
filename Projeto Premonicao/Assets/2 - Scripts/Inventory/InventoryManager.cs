using UnityEngine;
using System.Collections.Generic;

public class InventoryManager: MonoBehaviour {

    private static InventoryManager instance;

    public int MaxNumOfObjects;

    private List<Object> ObjectsInInventory = new List<Object>();

    public static InventoryManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
    }

    public void putIntemInInventory(Object interactiveObject) {

        // Add item in Inventory if it's not on it's limit
        if (ObjectsInInventory.Count < MaxNumOfObjects) {
            ObjectsInInventory.Add(interactiveObject);
        } else {
            Debug.Log("Atingiu o limite de objetos do inventário");
        }
    }
    
}
