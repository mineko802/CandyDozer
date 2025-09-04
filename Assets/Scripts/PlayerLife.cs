using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    
    //�v���C���[��HP���Ǘ�����ϐ�(�e�ՂɐG��Ȃ��悤��private�ȕϐ��ɂ���)
    [SerializeField]
    private int playerHitPiont = 3;

    //�v���C���[�̃��C�t��\�������鏈��
    //���C�t��\��������@���@UI��ϓ�������
    public List<GameObject> playerLifeUI;
    //�v���C���[���G�L�����N�^�[�ɓ����������̏���
    public bool hitFlag = false;

    //�v���C���[�̃��C�t�����炷����(�O������Ăяo��)
    public void PlayerHitPointDown()
    {
        //�� playerHitPoint = playerHitPoint - 1�̏������ȗ�����������
        playerHitPiont--;
        Debug.Log(playerHitPiont);
    }

    void Update()
    {
        //�v���C���[������ɓ���������HP�����炷�������Ă�
        if(hitFlag == true)
        {
            //HP�����炷�������Ă�
            PlayerHitPointDown();

           
            //playerLifeUI��i�Ԗڂ̃I�u�W�F�N�g������
            playerLifeUI[playerHitPiont].SetActive(false);
            
            hitFlag = false;
        }
        //HP�̐��ɂ���ĕ\������n�[�g��ω�������

    }
}
