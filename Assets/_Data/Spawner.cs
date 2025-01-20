using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public abstract class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabsList = new();
    [SerializeField] protected List<Transform> poolObjs = new();
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabsList();
        LoadHolder();
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabsList)
        {
            if (prefab == null) continue;
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        Transform gameObject = GetPrefabByName(prefab.gameObject.name);
        if (gameObject == null) return null;
        foreach (Transform child in poolObjs)
        {
            if (child.name == prefab.name) return child;
        }
        return null;
    }

    protected virtual void Spawn(string prefabName, Vector3 position)
    {
        Transform prefab = GetPrefabByName(prefabName);
        Transform gameObj = GetObjectFromPool(prefab);
        if (gameObj == null)
        {
            gameObj = Instantiate(prefab).transform;
            gameObj.SetLocalPositionAndRotation(position, Quaternion.identity);
            gameObj.SetParent(holder);
            gameObj.gameObject.SetActive(true);
        }
    }

    public virtual void Despawn(Transform gameObj)
    {
        poolObjs.Add(gameObj);
        gameObj.gameObject.SetActive(false);
    }

    protected virtual void LoadPrefabsList()
    {
        if (prefabsList.Count > 0) return;
        Transform prefabs = transform.Find("Prefabs");
        foreach (Transform child in prefabs)
        {
            prefabsList.Add(child);
        }
        HideAllPrefabs();
    }

    protected virtual void HideAllPrefabs()
    {
        foreach (Transform prefab in prefabsList) prefab.gameObject.SetActive(false);
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log($"{transform.name}: LoadHolder", gameObject);
    }
}
