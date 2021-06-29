using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerNewWorld : MonoBehaviour
{
    public CharacterController controlerPlayer;

    public float horizontalMove;
    public float verticalMove;
    public float speed;
    public float gravity;
    public float fallVelocity;

    private float horizontalAux;
    private float verticalAux;



    public Camera camara;
    private Vector3 playerInput;
    private Vector3 camaraForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    private bool canMovePlayer;



    private void Awake()
    {
        horizontalAux = 0;
        verticalAux = 0;
    }


    void Start()
    {
        controlerPlayer = GetComponent<CharacterController>();
        this.verticalMove = 0;
        this.horizontalMove = 0;
        this.gravity = 14f;
        this.canMovePlayer = true;
        //camara = Camera.main;

       
    }

    void Update()
    {
        MovementKeyBoard();
    }


    private void MovementKeyBoard()
    {
        if (this.canMovePlayer)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");


            playerInput = new Vector3(this.horizontalMove, 4, this.verticalMove);
            playerInput = Vector3.ClampMagnitude(this.playerInput, 1);

            DirectionCamara();

            movePlayer = playerInput.x * camRight + playerInput.z * camaraForward;

            controlerPlayer.transform.LookAt(this.controlerPlayer.transform.position + movePlayer);

            SetGravity();

            controlerPlayer.Move(this.movePlayer * speed * Time.deltaTime);
        }
    }


    private void DirectionCamara()
    {
        camaraForward = camara.transform.forward;
        camRight = camara.transform.right;

        camaraForward.y = 0;
        camRight.y = 0;

        camaraForward = camaraForward.normalized;
        camRight = camRight.normalized;
    }

    public void SetGravity()
    {
        if (this.controlerPlayer.isGrounded)
            this.fallVelocity = gravity * Time.deltaTime;
        else
            this.fallVelocity = gravity * Time.deltaTime;

        this.movePlayer.y -= this.fallVelocity;
    }

    public void SetMovementPlayer(bool valor)
    {
        this.canMovePlayer = valor;
    }


    public bool getReturnMovePlayer()
    {
        return canMovePlayer;
    }

}
