using UnityEngine;

public class MovementVR : MonoBehaviour
{
    public float moveForceMultiplier = 0.1f;



    public float MaxSpeed = 1.0f;



    float moveX = 0f;
    float moveZ = 0f;





    private float Speed = 0.0f;


    public Transform Head = null;

   
    private int GroundCount;

    private CapsuleCollider CapCollider;
    private new Rigidbody rigidbody;

    private Vector3 newCenter = Vector3.zero;

    public PhysicMaterial NoFrictionMaterial;
    public PhysicMaterial FrictionMaterial;

    public float slopeLimit = 45;
    private float m_SlideLimit;
    private Ray ray;

    public float AntiBumpFactor = -.75f;
    private float m_AntiBumpFactor = 0;

    public bool isGround = false;
    public bool isAngleGround = false;
    public bool FowerdIsAngled = false;


    private void Start()
    {
        CapCollider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();

        int layer1 = LayerMask.NameToLayer("MyBody");
        int layer2 = LayerMask.NameToLayer("MyHand");

        //Physics.IgnoreLayerCollision(layer1, layer2);

        m_SlideLimit = slopeLimit - .1f;

    }

    private void FixedUpdate()
    {
        //KillBounceCheckGround();

        //CheckGround();
        //CheckGroundAngleFowerd();

        //m_AntiBumpFactor = 0;

        //if (isGround && isAngleGround && !FowerdIsAngled)
        //{
        //    //m_AntiBumpFactor = -0.75f;

        //    rigidbody.AddForce(moveForceMultiplier * (new Vector3(0, AntiBumpFactor, 0)), ForceMode.Force);

        //}


        //CapCollider.material = NoFrictionMaterial;

        //if (isGround)
        //{
        //    CalculateMovement();

        //    CapCollider.material = FrictionMaterial;
        //}

        CalculateMovement();



        //HandleHeight();

    }


    public void CalculateMovement()
    {
        Vector3 moveVector = Vector3.zero;
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");


        moveVector = MaxSpeed * ( new Vector3(moveX, 0, moveZ).normalized);

        moveVector = transform.TransformDirection(moveVector);

        rigidbody.AddForce(moveForceMultiplier * (moveVector - rigidbody.velocity), ForceMode.Force);

        //Debug.Log("ああああああああああああああああああああああああああああああああああああ！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！");


    }

    private void HandleHeight()
    {
        float distanceFromFloor = Mathf.Clamp(Head.localPosition.y, 0.5f, 2);
        CapCollider.height = distanceFromFloor;

        newCenter = Vector3.zero;
        newCenter.y = CapCollider.height / 2;
        //newCenter.y += CapCollider.skinWidth;

        newCenter.x = Head.localPosition.x;
        newCenter.z = Head.localPosition.z;

        //newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        CapCollider.center = newCenter;


    }

    //public void KillBounceCheckGround()
    //{
    //    int layerMask = 1 << 9;
    //    layerMask = ~layerMask;

    //    if (GroundCount == 0)
    //    {
    //        RaycastHit Hit;
    //        if (Physics.SphereCast(Head.position, CapCollider.radius, Vector3.down, out Hit, SteamObjPlayer.eyeHeight + .2f, layerMask))
    //        {
    //            isBounce = true;

    //            Debug.Log(Vector3.Angle(Hit.normal, Vector3.up));
    //            m_AntiBumpFactor = AntiBumpFactor;
    //        }
    //        else
    //        {
    //            isBounce = false;
    //            m_AntiBumpFactor = 0;
    //        }
    //    }
    //    else
    //    {
    //        m_AntiBumpFactor = 0;
    //    }

    //}

    //public void CheckGround()
    //{
    //    int layerMask = 1 << 14 | 1 << 9;
    //    layerMask = ~layerMask;

    //    RaycastHit Hit;
    //    if (Physics.SphereCast(Head.position, CapCollider.radius, Vector3.down, out Hit, SteamObjPlayer.eyeHeight, layerMask))
    //    {
    //        isGround = true;

    //        if(Vector3.Angle(Hit.normal, Vector3.up) != 0)
    //        {
    //            isAngleGround = true;
    //        }
    //        else
    //        {
    //            isAngleGround = false;
    //        }

    //        //Debug.Log("今いる床の角度" + Vector3.Angle(Hit.normal, Vector3.up));
    //    }
    //    else
    //    {
    //        isGround = false;
    //        isAngleGround = false;
    //    }
    //}

    //public void CheckGroundAngleFowerd()
    //{
    //    int layerMask = 1 << 14;
    //    layerMask = ~layerMask;

    //    RaycastHit Hit;
    //    if (Physics.Raycast(SteamObjPlayer.feetPositionGuess, Quaternion.Euler(0, leftcontroller.transform.eulerAngles.y, 0) *  new Vector3(moveX, 0, moveZ), out Hit, .2f, layerMask))
    //    {
    //        if (Vector3.Angle(Hit.normal, Vector3.up) != 0)
    //        {
    //            FowerdIsAngled = true;
    //        }
    //        else
    //        {
    //            FowerdIsAngled = false;
    //        }

    //        //Debug.Log("目の前の角度"+Vector3.Angle(Hit.normal, Vector3.up));
    //    }
    //    else
    //    {
    //        FowerdIsAngled = false;
    //    }


    //    Debug.DrawRay(SteamObjPlayer.feetPositionGuess, Quaternion.Euler(0, leftcontroller.transform.eulerAngles.y, 0) * new Vector3(moveX, 0, moveZ), Color.yellow);
    //}


    //void OnDrawGizmos()
    //{
    //    //　Capsuleのレイを疑似的に視覚化
    //    //Gizmos.color = Color.red;
    //    //Gizmos.DrawWireSphere(SteamObjPlayer.feetPositionGuess, CapCollider.radius);
    //    //Gizmos.DrawWireSphere(Head.position, CapCollider.radius);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    GroundCount++;
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    GroundCount--;
    //}
}