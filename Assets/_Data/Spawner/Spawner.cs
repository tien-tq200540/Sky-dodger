using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new();
    [SerializeField] protected List<Transform> poolObjs = new();
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
        LoadHolder();
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab == null) continue;
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual Transform Spawn(string prefabName, Vector3 position)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning($"Prefab not found: {prefabName}");
            return null;
        }

        return this.Spawn(prefab, position);
    }

    protected virtual Transform Spawn(Transform prefab, Vector3 position)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, Quaternion.identity);
        newPrefab.SetParent(holder);
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    protected virtual void HideAllPrefabs()
    {
        foreach (Transform prefab in this.prefabs) prefab.gameObject.SetActive(false);
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabs = transform.Find("Prefabs");
        foreach (Transform child in prefabs)
        {
            this.prefabs.Add(child);
        }
        HideAllPrefabs();
        Debug.LogWarning($"{transform.name}: LoadPrefabs", gameObject);
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning($"{transform.name}: LoadHolder", gameObject);
    }
}
