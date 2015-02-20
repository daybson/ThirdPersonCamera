using UnityEngine;
using System.Collections;

public class TP_Controller : MonoBehaviour
{
    public static CharacterController CharacterController;
    public static TP_Controller Instance;

    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        Instance = this;
        TP_Camera.UseExistingOrCreateNewMainCamera();
    }

    void Update()
    {
        if (Camera.main == null)
            return;

        GetLocomotion();

        TP_Motor.Instance.UpdateMotor();
    }

    void GetLocomotion()
    {
        var deadZone = 0.1f;
        TP_Motor.Instance.MoveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
        {
            TP_Motor.Instance.MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            TP_Motor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }

        Debug.Log(TP_Motor.Instance.MoveVector);
    }


}
