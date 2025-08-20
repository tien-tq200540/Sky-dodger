using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : TienMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private float playerMovementInput;
    public float PlayerMovementInput => playerMovementInput;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 InputManager allows to exist!");
        else instance = this;
    }

    private void Update()
    {
        this.UpdatePlayerMovementInput();
    }

    private void UpdatePlayerMovementInput()
    {
        this.playerMovementInput = Input.GetAxisRaw("Horizontal");
    }
}
