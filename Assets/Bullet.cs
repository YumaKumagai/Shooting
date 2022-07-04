using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //移動速度
    public float moveVelo;
    //進んだら消滅する距離
    public float limitDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //弾のワールド座標を取得
        Vector3 pos = transform.position;

        //上にまっすぐ飛ぶ
        pos.z += moveVelo;

        //弾の移動
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //一定距離進んだら消滅する
        if (pos.z >= limitDistance)
        {
            Destroy(this.gameObject);
        }
    }

    //当たり判定用関数
    private void OnTriggerEnter(Collider other)
    {
        //もし当たったオブジェクトのタグがEnemyだったら
        if (other.gameObject.tag == "Enemy")
        {
            //当たったオブジェクトのEnemyスクリプトを
            //呼び出してDamage関数を実行させる
            other.GetComponent<Enemy>().Damage();

            //自己消滅する
            Destroy(this.gameObject);
        }
    }
}
