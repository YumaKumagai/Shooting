using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���C���X�y�N�^�[����Q�Ƃ��邽�߂̕ϐ�
    public GameObject Bullet;
    //���˃L�[
    public UnityEngine.KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[���������u��(1�t���[��)
        if(Input.GetKeyDown(keyCode))
        {
            //�e�𐶐�����
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
