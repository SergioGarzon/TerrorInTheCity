using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public Vector3 distanceCamera;
    private Transform targetPlayer;  //Este es el currentView

    public Transform objectCubo1;
    public Transform objectCubo2;

    [Range(0, 1)] public float lerpValue;
    public float sensibilidad;

    private bool validationBattle;
    private bool validation1;

    private bool canMoveCamera;

    void Start()
    {
        targetPlayer = GameObject.Find("Capsule").transform.GetChild(0).transform;
        this.validationBattle = false;
        this.validation1 = false;
        this.canMoveCamera = true;
    }

    void Update()
    {
        if (this.canMoveCamera)
        {
            if (!targetPlayer.gameObject.activeSelf)
            {
                this.validationBattle = true;
                this.targetPlayer = this.objectCubo1.transform;
            }

            if (this.validation1)
            {
                this.targetPlayer = this.objectCubo2.transform;
            }
        }
    }

    void LateUpdate()
    {
        if (this.canMoveCamera)
        {
            if (this.validationBattle == false)
            {
                transform.position = Vector3.Lerp(transform.position, targetPlayer.position + distanceCamera, lerpValue);
                this.distanceCamera = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * +sensibilidad, Vector3.up) * this.distanceCamera;
                transform.LookAt(this.targetPlayer);
            }

        }
    }


    public void setCameraMovement(bool camaraCanMove)
    {
        this.canMoveCamera = camaraCanMove;
    }
}
