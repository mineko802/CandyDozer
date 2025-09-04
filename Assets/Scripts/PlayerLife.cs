using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    
    //プレイヤーのHPを管理する変数(容易に触れないようにprivateな変数にする)
    [SerializeField]
    private int playerHitPiont = 3;

    //プレイヤーのライフを表示させる処理
    //ライフを表示させる　＝　UIを変動させる
    public List<GameObject> playerLifeUI;
    //プレイヤーが敵キャラクターに当たった時の処理
    public bool hitFlag = false;

    //プレイヤーのライフを減らす処理(外部から呼び出す)
    public void PlayerHitPointDown()
    {
        //↓ playerHitPoint = playerHitPoint - 1の処理を省略した書き方
        playerHitPiont--;
        Debug.Log(playerHitPiont);
    }

    void Update()
    {
        //プレイヤーが相手に当たったらHPを減らす処理を呼ぶ
        if(hitFlag == true)
        {
            //HPを減らす処理を呼ぶ
            PlayerHitPointDown();

           
            //playerLifeUIのi番目のオブジェクトを消す
            playerLifeUI[playerHitPiont].SetActive(false);
            
            hitFlag = false;
        }
        //HPの数によって表示するハートを変化させる

    }
}
