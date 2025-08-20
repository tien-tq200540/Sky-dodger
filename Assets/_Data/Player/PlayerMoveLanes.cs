using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLanes : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> lanes = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLanes();
    }

    protected virtual void LoadLanes()
    {
        if (this.lanes.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            this.lanes.Add(child);
        }
        Debug.LogWarning($"{transform.name}: LoadLanes", gameObject);
    }

    public virtual Transform GetLane(int index)
    {
        if (index < 0 || index >= lanes.Count) return null;
        return this.lanes[index];
    }
}
