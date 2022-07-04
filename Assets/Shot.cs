using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //ゲームオブジェクトをインスペクターから参照するための変数
    public GameObject Bullet;
    //発射キー
    public UnityEngine.KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キーを押した瞬間(1フレーム)
        if(Input.GetKeyDown(keyCode))
        {
            //弾を生成する
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
