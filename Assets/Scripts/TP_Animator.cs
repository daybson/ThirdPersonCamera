using UnityEngine;
using System.Collections;

public class TP_Animator : MonoBehaviour
{
    public enum Direction
    {
        Stationary,
        Forward,
        Backward,
        Left,
        Rigth,
        LeftForward,
        RightForward,
        LeftBackward,
        RightBackward
    }

    public static TP_Animator Instance;

    public Direction MoveDIrection
    {
        get;
        set;
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {

    }

    public void DetermineCurrentMoveDirection()
    {
        var forward = false;
        var backward = false;
        var left = false;
        var right = false;

        if (TP_Motor.Instance.MoveVector.z > 0)
            forward = true;

        if (TP_Motor.Instance.MoveVector.z < 0)
            backward = true;

        if (TP_Motor.Instance.MoveVector.x > 0)
            right = true;

        if (TP_Motor.Instance.MoveVector.x < 0)
            left = true;

        if (forward)
        {
            if (left)
                MoveDIrection = Direction.LeftForward;
            else if (right)
                MoveDIrection = Direction.RightForward;
            else
                MoveDIrection = Direction.Forward;
        }
        else if (backward)
        {
            if (left)
                MoveDIrection = Direction.LeftBackward;
            else if (right)
                MoveDIrection = Direction.RightBackward;
            else
                MoveDIrection = Direction.Backward;
        }
        else if (left)
            MoveDIrection = Direction.Left;
        else if (right)
            MoveDIrection = Direction.Rigth;
        else
            MoveDIrection = Direction.Stationary;
    }
}
