/* Resource Manager v1.1
 * 
 * Este sistema controla la generacion repetitiva de objetos de corta vida.
 * Evita que los objetos sean creados y destruidos constantemente,
 * usando en cambio un pool de objetos que recicla constantemente,
 * sumando nuevas instancias solo cuando es necesario.
 * 
 * USO:
 * 1) Crear un objeto en la escena, y agregarle este script como componente.
 * Los objetos se crearan como hijos de este objeto.
 * 2) En el Editor, agregar a resourcesToManage todos los prefab de los objetos
 * que este sistema vaya a manejar.
 * 3) Para pedir una instancia de algun recurso, usar:
 *      ResourcePool.instance.Get(hash)
 *      donde hash es la funcion getHashCode del prefab del GameObject  del recurso.
 */ 

using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour {

    private static ResourcePool instance;

    [SerializeField] List<GameObject> resourcesToManage;
    Pool[] pools;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            throw new Exception("You should only have one ResourcePool per scene");
        }
        CreatePools();
    }

    private void CreatePools() {
        pools = new Pool[resourcesToManage.Count];

        for (int index = 0; index < resourcesToManage.Count; index++) {
            pools[index] = Pool.Create(resourcesToManage[index], transform);
        }
    }

    public static GameObject Get(int hash) {
        for (int i = 0; i < instance.pools.Length; i++) {
            if (instance.pools[i].CheckForHash(hash)) {
                return instance.pools[i].Get();
            }
        }
        throw new Exception("Requested Hash not found");
    }

    public static GameObject Get(GameObject prefab) {
        return Get(prefab.GetHashCode());
    }
}
