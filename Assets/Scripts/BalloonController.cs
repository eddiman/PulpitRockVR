using System;
using Assets.Scripts;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public Transform balloonTrans;
    public Rigidbody balloonTransRigidBody;

    public float maxForwardSpeed;
    public float maxUpSpeed;
    public float maxRotation;

    private Vector2 primaryThumb;
    private Vector2 secondaryThumb;
    private Vector3 _eulerAngleVelocity;
    private float LeftTigger;

    [SerializeField]
    private float currentForwardSpeed = 5f;
    [SerializeField]
    private float currentUpSpeed = 3f;
    [SerializeField]
    private float rotationSpeed = 2.5f;

    private SceneController SceneManager;
    // Start is called before the first frame update
    void Start()
    {
        balloonTransRigidBody = balloonTrans.GetComponent<Rigidbody>();
        _eulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
        SceneManager = GameObject.Find("SceneManager").GetComponent<SceneController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Eventual rewrite to Events and listener, bad practice this is
        if (SceneManager.gameState != SceneController.GameState.inBalloon) return;

        primaryThumb = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        if (Math.Abs(primaryThumb.y) > 0.001f)
        {
            currentForwardSpeed = primaryThumb.y * maxForwardSpeed;
            //balloonTransRigidBody.velocity = transform.forward * currentForwardSpeed;
            balloonTransRigidBody.AddForce(balloonTrans.forward * currentForwardSpeed);
        }

        secondaryThumb = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        if (Math.Abs(secondaryThumb.x) > 0.001f)
        {
            rotationSpeed = secondaryThumb.x * maxRotation;
            balloonTransRigidBody.AddTorque(balloonTrans.up * rotationSpeed);
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            float currentY = balloonTrans.rotation.y;
            balloonTrans.rotation = Quaternion.Euler(0,currentY,0);
            balloonTransRigidBody.velocity = Vector3.zero;
            balloonTransRigidBody.angularVelocity = Vector3.zero;
        }

        LeftTigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        if (Math.Abs(LeftTigger) > 0.001f)

            currentUpSpeed = LeftTigger * maxUpSpeed;
        balloonTransRigidBody.AddForce(balloonTrans.up * currentUpSpeed);


    }
}
