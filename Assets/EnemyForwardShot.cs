using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のプレハブを入れる
    public GameObject bullet;

    //打ち出す間隔決める
    public float time = 1;

    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;

    //現在のタイマー時間
    float nowtime = 0;

    //弾の速度
    public float bulletSpeed;

    //弾の消滅までの時間
    public float bulletTime;

    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入っていなかったら
        if (player == null)
        {
            //プロジェクトのPlayerを探して情報を取得する
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //タイマーを減らす
        nowtime -= Time.deltaTime;

        //もしタイマーが0以下になったら
        if (nowtime <= 0)
        {
            //弾を生成
            CreateShotObject(-transform.localEulerAngles.y);

            //タイマーを初期化
            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        //ベクトルを取得
        var direction = player.transform.position - transform.position;

        //ベクトルのyを初期化
        direction.y = 0;

        //向きを取得する
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //弾を生成する
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        bulletClone.GetComponent<EnemyBullet>().speed = bulletSpeed;
        bulletClone.GetComponent<EnemyBullet>().time = bulletTime;

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
