using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy6 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    float rotation_speed =0;//��]�X�s�[�h
    [SerializeField] private GameObject enemy6shotr;//�E�ւ̍U��
    [SerializeField] private GameObject enemy6shotl;//���ւ̍U��
    [SerializeField] private GameObject enemy6shotrh;//�E(��)�̐����ʒu
    [SerializeField] private GameObject enemy6shotlh;//��(��)�̐����ʒu
    [SerializeField] private GameObject enemy6shotrhd;//�E(��)�̐����ʒu
    [SerializeField] private GameObject enemy6shotlhu;//��(��)�̐����ʒu
    [SerializeField] private GameObject Coin;//�R�C��
    [SerializeField] private GameObject Food;//�H�ו�
    [SerializeField] private GameObject Gold;//����
    [SerializeField] private GameObject Shot;//�U��(�ǐ�)

    private float span = 0.5f;//enemy6shotr(��)������������Ԋu
    private float span2 = 1.0f;//enemy6shotl(��)������������Ԋu
    private float span3 = 1.5f;//enemy6shotr(��)������������Ԋu
    private float span4 = 2.0f;//enemy6shotl(��)������������Ԋu
    private float span5 = 3.0f;//shot������������Ԋu
    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float time4 = 0f;
    private float time5 = 0f;
    private float hp = 700;//�ő�HP
    private float nowhp;//���݂�HP
    private float stoptime = 0f;
    private float stop = 9.0f;//��]���鎞�Ԃ̊Ԋu
    private float arealr = 0.0f;//�U���͈�(���E)
    private float areaud = 0.0f;//�U���͈�(�㉺)
    [SerializeField] private Slider hpSlider;//HP�o�[
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;
        hpSlider.value = 1;//HP�o�[�𖞃^���ɂ���
        nowhp = hp;//���݂�HP���{�X��HP�Ƃ���
    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //�v���C���[���͈͓��ɓ������玞�Ԃ��v��
        if (arealr < 60.0f && arealr > -60.0f)
        {
            if (areaud < 60.0f && areaud > -60.0f)
            {
                stoptime += Time.deltaTime;
                time5 += Time.deltaTime;
                //stoptime/10�̂��܂肪stop�ȉ��ɂȂ������]����
                if (stoptime % 10 <= stop)
                {
                    this.rotation_speed = 0.5f;
                    transform.Rotate(0, 0, this.rotation_speed);
                    time += Time.deltaTime;
                    time2 += Time.deltaTime;
                    time3 += Time.deltaTime;
                    time4 += Time.deltaTime;
                    //span�b�o�߂�����enemy6shotr�𐶐���enemy6shotrh�ɐ�������
                    if (time > span)
                    {
                        Instantiate(enemy6shotr);
                        enemy6shotr.transform.position = enemy6shotrh.transform.position;
                        time = 0f;

                    }
                    //span2�b�o�߂�����enemy6shotl�𐶐���enemy6shotlh�ɐ�������
                    else if (time2 > span2)
                    {
                        Instantiate(enemy6shotl);
                        enemy6shotl.transform.position = enemy6shotlh.transform.position;
                        time2 = 0f;
                    }
                    //span3�b�o�߂�����enemy6shotr�𐶐���enemy6shotrhd�ɐ�������
                    else if (time3 > span3)
                    {
                        Instantiate(enemy6shotr);
                        enemy6shotr.transform.position = enemy6shotrhd.transform.position;
                        time3 = 0f;

                    }
                    //span4�b�o�߂�����enemy6shotl�𐶐���enemy6shotlhu�ɐ�������
                    else if (time4 > span4)
                    {
                        Instantiate(enemy6shotl);
                        enemy6shotl.transform.position = enemy6shotlhu.transform.position;
                        time4 = 0f;
                    }
                }
                //span5�b�o�߂�����shot�𐶐�
                if (time5 % 10 > span5)
                {
                    Instantiate(Shot);
                    Shot.transform.position = this.transform.position;
                    time5 = 0f;
                }
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;//�R�C�����o�����o���Ȃ����̔���
        int food = 0;//�H�ו����o�����o���Ȃ����̔���
        int gold = 0;//�������o�����o���Ȃ����̔���
        int c = 0;//�o�������R�C���̖���
        int g = 0;//�o�����������̖���

        //Bullet�ɓ��������Ȃ猻�݂�HP��Power�Ԃ񌸂炵�AHP�o�[�ɂ����f������
        if (other.gameObject.tag == "Bullet")
        {
            nowhp -= script.Power;
            hpSlider.value = nowhp / hp;
        }
        //Gun�ɓ��������Ȃ猻�݂�HP��Power/2�Ԃ񌸂炵�AHP�o�[�ɂ����f������
        if (other.gameObject.tag == "Gun")
        {
            nowhp -= (script.Power / 2);
            hpSlider.value = nowhp / hp;
        }
        //Explosion�ɓ��������Ȃ猻�݂�HP��50���炵�AHP�o�[�ɂ����f������
        if (other.gameObject.tag == "Explosion")
        {
            nowhp -= 50;
            hpSlider.value = nowhp / hp;
        }

        //���݂�HP��0�Ȃ�
        if (nowhp <= 0)
        {
            coin = Random.Range(0, 2);
            food = Random.Range(0, 2);
            gold = Random.Range(0, 2);
            //coin�̒l��1�Ȃ炃��10�ȏ�ɂȂ�܂ŃR�C���𐶐�����
            if (coin == 1)
            {
                while (c < 10)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Coin, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    c++;
                }

            }

            //food�̒l��1�Ȃ�H�ו��𐶐�����
            if (food == 1)
            {
                Instantiate(Food, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }

            //gold�̒l��1�Ȃ�g��10�ȏ�ɂȂ�܂Ŏ����𐶐�����
            if (gold == 1)
            {
                while (g < 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Gold, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    g++;
                }

            }
            this.gameObject.SetActive(false);//���̃I�u�W�F�N�g������
        }

    }

}
