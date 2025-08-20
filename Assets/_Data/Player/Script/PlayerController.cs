using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TienMonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance => instance;

    #region Field

    [SerializeField] protected PlayerPhysicsHandler playerPhysics;
    [SerializeField] protected PlayerMoveLanes playerMoveLanes;

    #endregion

    #region Property

    public PlayerPhysicsHandler PlayerPhysics => playerPhysics;
    public PlayerMoveLanes PlayerMoveLanes => playerMoveLanes;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 PlayerController allows to exist!");
        else instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPhysicsHandler();
        this.LoadPlayerMoveLanes();
    }

    protected virtual void LoadPlayerPhysicsHandler()
    {
        if (this.playerPhysics != null) return;
        this.playerPhysics = GetComponent<PlayerPhysicsHandler>();
        Debug.LogWarning($"{transform.name}: LoadPlayerPhysicsHandler", gameObject);
    }

    protected virtual void LoadPlayerMoveLanes()
    {
        if (this.playerMoveLanes != null) return;
        this.playerMoveLanes = GameObject.FindAnyObjectByType<PlayerMoveLanes>();
        Debug.LogWarning($"{transform.name}: LoadPlayerMoveLanes", gameObject);
    }
}
