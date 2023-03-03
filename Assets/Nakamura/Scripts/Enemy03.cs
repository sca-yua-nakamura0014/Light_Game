using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy03 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    [SerializeField] private GameObject Coin;//�R�C��
    [SerializeField] private GameObject Food;//�H�ו�
    [SerializeField] private GameObject Silver;//����
    public Slider hpSlider;//HP�o�[
    private float Speed = 3;//�ړ����x
    private float hp = 300;//�ő�HP
    private float nowhp;//���݂�HP
    private float arealr = 0.0f;//�U���͈�(���E)
    private float areaud = 0.0f;//�U���͈�(�㉺)
    private float x;//�����ʒu�ix���W�j
    private float y;//�����ʒu�i�����W�j
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;//HP�o�[�𖞃^���ɂ���
        nowhp = hp;//���݂�HP���ő��HP�Ƃ���
        x = this.transform.position.x;
        y = this.transform.position.y;
    }

    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //�v���C���[���͈͂ɓ�������v���C���[�̕����ֈړ�����
        if (arealr < 35.0f && arealr > -35.0f)
        {
            if (areaud < 35.0f && areaud > -35.0f)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y), Speed * Time.deltaTime);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Wall,Botton,Door�̂ǂꂩ�ɓ��������珉���ʒu�ւƖ߂�
        if (other.gameObject.tag == "Wall"|| other.gameObject.tag == "Botton" || other.gameObject.tag == "Door")
        {
            this.transform.position = new Vector2(x, y);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        int coin = 0;//�R�C�����o�����o���Ȃ����̔���
        int food = 0;//�H�ו����o�����o���Ȃ����̔���
        int silver = 0;//�������o�����o���Ȃ����̔���
        int c = 0;//�o�������R�C���̖���
        int s = 0;//�o�����������̖���

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
            silver = Random.Range(0, 2);

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

            //silver�̒l��1�Ȃ�s��10�ȏ�ɂȂ�܂Ŏ����𐶐�����
            if (silver == 1)
            {
                while (s < 1)
                {
                    float x = Random.Range(this.transform.position.x + 2, this.transform.position.x - 2);
                    Instantiate(Silver, new Vector2(x, this.transform.position.y), Quaternion.identity);
                    s++;
                }

            }
            this.gameObject.SetActive(false);//���̃I�u�W�F�N�g������
        }
    }
}
