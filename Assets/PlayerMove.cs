using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    //�ړ����x
    public float moveVelo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;
        //�ړ�����(-1�œ����Ȃ�)
        int moveAngle = -1;
        //�e���̒l
        int moveX = 0, moveZ = 0;
        //�ړ��x�N�g��
        Vector3 moveVector = new Vector3(0, 0, 0);

        //X���擾
        moveX -= Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow));
        moveX += Convert.ToInt32(Input.GetKey(KeyCode.RightArrow));
        //Y���擾
        moveZ += Convert.ToInt32(Input.GetKey(KeyCode.UpArrow));
        moveZ -= Convert.ToInt32(Input.GetKey(KeyCode.DownArrow));

        //�e���̒l����������Z�o
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
                //����������Ă��Ȃ���΁AmoveAngle=-1�ł���
            }
        }

        //���x�ƕ�������moveVector���Z�o
        if (moveAngle != -1)
        {
            moveVector.x = moveVelo * Mathf.Cos(moveAngle * (Mathf.PI / 180));
            moveVector.z = moveVelo * Mathf.Sin(moveAngle * (Mathf.PI / 180));
        }

        //�ړ�
        pos += moveVector;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
