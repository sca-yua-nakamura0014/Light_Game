using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy5 : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    Rigidbody2D rb;
    private float hp =700;//�ő�HP
    private float nowhp;//���݂�HP
    [SerializeField] private GameObject Coin;//�R�C��
    [SerializeField] private GameObject Food;//�H�ו�
    [SerializeField] private GameObject Gold;//����
    public Slider hpSlider;//HP�o�[
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;//HP�o�[�𖞃^���ɂ���
        nowhp = hp;//���݂�HP���ő��HP�Ƃ���
    }

    void Update()
    {
       
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
                while(g < 1)
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