using UnityEngine;

public class PlayerMovement : ObjectMoveToTarget
{
    public float direction;
    public bool canSwitchLane = true;
    public bool isSwitchLane = false;
    public int currentLane = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    private void Update()
    {
        direction = InputManager.Instance.PlayerMovementInput;
        if (canSwitchLane && direction != 0f)
        {
            if (!isSwitchLane)
            {
                isSwitchLane = true;
                currentLane += (int)direction;
                if (currentLane < 0) currentLane = 0;
                else if (currentLane > 2) currentLane = 2;
                this.target = PlayerController.Instance.PlayerMoveLanes.GetLane(currentLane).position;
            }
        }
    }

    private void FixedUpdate()
    {
        this.MoveToTarget();
    }

    protected override void MoveToTarget()
    {
        if (this.target == null) return;
        if (transform.position == this.target) return;
        Vector3 newPos = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        if (newPos == target) isSwitchLane = false;
        PlayerController.Instance.PlayerPhysics.MoveTo(newPos);
        Debug.Log("SwitchLane");
    }
}
