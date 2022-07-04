using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    //移動速度
    public float moveVelo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;
        //移動方向(-1で動かない)
        int moveAngle = -1;
        //各軸の値
        int moveX = 0, moveZ = 0;
        //移動ベクトル
        Vector3 moveVector = new Vector3(0, 0, 0);

        //X軸取得
        moveX -= Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow));
        moveX += Convert.ToInt32(Input.GetKey(KeyCode.RightArrow));
        //Y軸取得
        moveZ += Convert.ToInt32(Input.GetKey(KeyCode.UpArrow));
        moveZ -= Convert.ToInt32(Input.GetKey(KeyCode.DownArrow));

        //各軸の値から方向を算出
        if (Convert.ToBoolean(moveZ))
        {
            if (moveX < 0)
            {
                moveAngle = 135;
            }
            else if (moveX > 0)
            {
                moveAngle = 45;
            }
            else
            {
                moveAngle = 90;
            }
            moveAngle *= moveZ;
        }
        else
        {
            if (moveX < 0)
            {
                moveAngle = 180;
            }
            else if (moveX > 0)
            {
                moveAngle = 0;
            }
            else
            {
                //何も押されていなければ、moveAngle=-1である
            }
        }

        //速度と方向からmoveVectorを算出
        if (moveAngle != -1)
        {
            moveVector.x = moveVelo * Mathf.Cos(moveAngle * (Mathf.PI / 180));
            moveVector.z = moveVelo * Mathf.Sin(moveAngle * (Mathf.PI / 180));
        }

        //移動
        pos += moveVector;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
