using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //移動処理
    public float speed = 3.0f;
    protected Vector3 Character_pos; //キャラクターのポジション
    protected float x; //x方向のImputの値
    protected float z; //z方向のInputの値
    protected Rigidbody rigd;

    //カメラ処理
    public float x_sensi;
    public float y_sensi;
    public new GameObject camera;
    public Vector3 cameraAngle;
    [SerializeField] GameObject head;


    //アニメーション処理
    protected Animator animator = null;
    protected bool Carry_Flag = false;
    protected bool Carry_Flag_Idle = false;

    protected void Init()
    {
        Character_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
        rigd = GetComponent<Rigidbody>(); //プレイヤーのRigidbodyを取得
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        head.transform.localEulerAngles = new Vector3(0, 0, -cameraAngle.x);
    }

    protected void Player_Camera()
    {
        float x_Routation = Input.GetAxis("Mouse X");
        float y_Routation = Input.GetAxis("Mouse Y");
        x_Routation *= x_sensi;
        y_Routation *= y_sensi;
        this.transform.Rotate(0, x_Routation, 0);
        camera.transform.Rotate(-y_Routation, 0, 0);
        cameraAngle = camera.transform.localEulerAngles;
        if(cameraAngle.x < 280 && cameraAngle.x > 180)
        {
            cameraAngle.x = 280;
        }
        if(cameraAngle.x > 45 && cameraAngle.x < 180)
        {
            cameraAngle.x = 45;
        }
        cameraAngle.y = 0;
        cameraAngle.z = 0;
        camera.transform.localEulerAngles = cameraAngle;
    }

    protected void Move()
    {
        x = Input.GetAxisRaw("Horizontal"); //x方向のInputの値を取得
        z = Input.GetAxisRaw("Vertical"); //z方向のInputの値を取得
    }

    protected void Carry()
    {
        //モノを持つ判定
        if (Input.GetKeyDown("space") && Carry_Flag == false)
        {
            Debug.Log("持った");
            Carry_Flag = true;
            Carry_Flag_Idle = true;
            animator.SetInteger("StateID", 10);
        }

        else if (Input.GetKeyDown("space") && Carry_Flag == true)
        {
            Debug.Log("下した");
            animator.SetInteger("StateID", 12);
            Carry_Flag = false;
            Carry_Flag_Idle = false;
        }
        else if (Carry_Flag_Idle)
        {
            animator.SetInteger("StateID", 11);
            if (Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("up") || Input.GetKey("down"))
            {

                animator.SetInteger("StateID", 14);
            }
        }
    }
    public void TextRead()
    {
        Debug.Log("Text");
    }
}
