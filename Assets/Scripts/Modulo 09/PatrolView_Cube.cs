using TMPro;
using UnityEngine;

public class PatrolView_Cube : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Patrol_Cube PatrolComponent;

    void Start()
    {
        PatrolComponent.OnStartedMoving += StartedMovingEventHandler;
        PatrolComponent.OnStoppedMoving += StoppedMovingEventHandler;
    }

    private void StartedMovingEventHandler(int value)
    {
        switch (value)
        {
            case 0:
                Text.text = "Left";
                break;
            case 1:
                Text.text = "Right";
                break;
            case 2:
                Text.text = "Top";
                break;
            case 3:
                Text.text = "Bottom";
                break;
        }

    }
    private void StoppedMovingEventHandler()
    {
        Text.text = "Idle";
    }
}
