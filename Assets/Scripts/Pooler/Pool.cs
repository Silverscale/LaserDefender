using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool{
    private List<GameObject> instances;
    private GameObject prefab;
    private Transform folder;

    public static Pool Create(GameObject prefab, Transform parent) {
        var newPool = new Pool();

        newPool.prefab = prefab;
        newPool.SetFolder(parent);
        newPool.instances = new List<GameObject>();
        for (int i = 0; i < 3; i++) {
            newPool.AddInstance();
        }
        return newPool;
    }

    private void SetFolder(Transform parent) {
        folder = new GameObject().transform;
        folder.SetParent(parent);
        folder.name = "Pool of " + prefab.name;
    }

    public GameObject Get() {
        foreach (GameObject item in instances) {
            if (!item.activeSelf) {
                return item;
            }
        }
        var newItem = AddInstance();
        return newItem;
    }

    private GameObject AddInstance() {
        GameObject newObject = GameObject.Instantiate(prefab, folder);
        newObject.SetActive(false);
        instances.Add(newObject);
        return newObject;
    }
       
    public bool CheckForHash(int hash) {
        return prefab.GetHashCode() == hash;
    }
}
