using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    //�^�[�Q�b�g�L�����N�^�[�̕ێ��p�ϐ�
    public Transform character;
    //�X�e�[�W��Prefab��z��ŊǗ�����ϐ�
    public GameObject[] stageChip;
    //Scene�Ɏ��̉��������X�e�[�W��Prefab���Ǘ�����z��
    public List<GameObject> generateStageList = new List<GameObject>();
    //�X�e�[�W�����J�E���g����C���f�b�N�X
    public int preInstance = 5;
    //
    public int currentChipIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�̌��݈ʒu���猻�݂̃X�e�[�W�`�b�v�̃C���f�b�N�X���v�Z
        int characterPositionIndex = (int)(character.position.z / 30f);

        //�L�����N�^�[���i�񂾂�X�e�[�W�`�b�v��ǉ��Ő�������
        for (int i = preInstance + characterPositionIndex; i >= preInstance; i++)
        {
            //�ŏ��ɍ�����X�e�[�W���{�����̒ʉ߂����X�e�[�W�������X�e�[�W�𐶐�����
            if(generateStageList.Count > preInstance + characterPositionIndex)
            {
                return;
            }
            //�����𐶐�����
            int randomValue = Random.Range(0, stageChip.Length);

            GameObject stageObejct = Instantiate(stageChip[randomValue]);
            stageObejct.transform.position = new Vector3(0, 0, currentChipIndex * 30f);
            //���������X�e�[�W�`�b�v���Ǘ����X�g�ɒǉ�
            generateStageList.Add(stageObejct);
            currentChipIndex++;
        }
    }
}
