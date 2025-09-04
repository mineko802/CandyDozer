using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour
{

    // Start is called before the first frame update

    //1.�v���C���[�̃L�[���͂��󂯎��
    //2.�L�[���͂̕����Ɉړ�����
    //3.�ړ������ɍ��킹�ăA�j���[�V�������Đ�����
    
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    public float speed = 0f;
    Animator animator;
    //�W�����v�̍��������߂�ϐ�
    public float jumpPower = 0f;

    //�d�͂̋��������߂�ϐ�
    public float GravityPower = 0;

    //���C���̐��̍ő�l
    int MaxLine = 2;
    //���C���̐��̍ŏ��l
    int MinLine = -2;
    //���C���Ԃ̋���
    float LineWidth = 1.0f;
    //�ړ���̃��C��
    int targetLine = 0;
    //�G�L�����N�^�[�Ɠ��������ɒ�~���鎞��
    float StunTime = 0.5f;
    //�L�����N�^�[���~�܂��Ă��瓮���o���܂ł̕��A����
    float recoverTime = 0.0f;
    //�v���C���[��HP
    public int playerHitPoint = 3;
    //�O���̏����i�N���X�j��ϐ��Ƃ��ēǂݍ���
    public PlayerLife playerLife;

    //�L�����N�^�[���X�^���������f����N���X
    bool IsStun()
    {
        return recoverTime > 0.0f;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded) {
            //�˂������W�����v�������Ȃ�����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpPower;
            }
        }

        if (IsStun() == true)
        {
            moveDirection.x = 0f;
            moveDirection.z = 0f;
            recoverTime -= Time.deltaTime;
        }

        if (IsStun() == false)
        {
            float movePoerZ = moveDirection.z + (speed * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(movePoerZ, 0f, speed);
        }

        //x�����͖ڕW�̃|�W�V�����܂ł̍����ő��x���o��
        float ratioX = (targetLine * LineWidth - transform.position.x) / LineWidth;
        moveDirection.x = ratioX * speed;
        //�E���[���؂�ւ�
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            if(controller.isGrounded && targetLine < MaxLine)
            {
                targetLine = targetLine + 1;
            }
        }
        //���̃��[���؂�ւ�
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            if (controller.isGrounded && targetLine > MinLine)
            {
                targetLine = targetLine - 1;
            }
        }

        //�L�����N�^�[���d�͂ŗ������鏈��
        moveDirection.y = moveDirection.y - GravityPower * Time.deltaTime;

        //�ړ��ʂ�Transform�ɕϊ�����
        Vector3 globalDirection = transform.TransformDirection(moveDirection);

        //Controller�Ɉړ��ʂ�n��
        controller.Move(globalDirection * Time.deltaTime);

        //�˂����̃A�j���[�V�������ŐV�ɂ���
        animator.SetBool("run", moveDirection.z > 0f);
    }

    //�G�L�����N�^�[�ɓ��������ꍇ�̏�����ǉ�
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Robo")
        {
            Debug.Log("�G�ɂԂ������I");
            recoverTime = StunTime;
            playerHitPoint--;
            //�˂����̃A�j���[�V�������Đ�
            animator.SetTrigger("damage");
            Destroy(hit.gameObject);
            playerLife.hitFlag = true;
        }
    }
}

