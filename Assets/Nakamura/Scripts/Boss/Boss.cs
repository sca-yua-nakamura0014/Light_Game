using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    SpriteRenderer MainSpriteRendererD;
    SpriteRenderer MainSpriteRendererU;
    SpriteRenderer MainSpriteRendererR;
    SpriteRenderer MainSpriteRendererL;
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite atk;//�{�X�̍U���̉摜
    [SerializeField] private Sprite o2up; //�{�X�̍U��(�_�f)�̉摜
    [SerializeField] private Sprite explosion;//�������̉摜
    [SerializeField] private GameObject enemyshotR;//�E�ւ̍U��
    [SerializeField] private GameObject enemyshotL;//���ւ̍U��
    [SerializeField] private GameObject enemyshotU;//��ւ̍U��
    [SerializeField] private GameObject enemyshotD;//���ւ̍U��
    [SerializeField] private GameObject enemy6r;//right����(��)�̍U��
    [SerializeField] private GameObject enemy6l;//left����(��)�̍U��
    [SerializeField] private GameObject enemy6rd;//enemy6r�̐����ʒu
    [SerializeField] private GameObject enemy6ld;//enemy6l�̐����ʒu
    [SerializeField] private GameObject enemy6R;//right����(��)�̍U��
    [SerializeField] private GameObject enemy6L;//left����(��)�̍U��
    [SerializeField] private GameObject enemy6ru;//enemy6R�̐����ʒu
    [SerializeField] private GameObject enemy6lu;//enemy6L�̐����ʒu
    [SerializeField] private Slider hpSlider;//HP�o�[
    [SerializeField] private GameObject Coin;//�R�C��
    private float span = 1.0f;//enemy6r,enemy6L�����������Ԋu
    private float span2 = 1.5f;//enemy6l,enemy6R�����������Ԋu
    private float span3 = 3.0f;//enemyshotR�`enemyshotD�����������Ԋu
    private float time1 = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private int o2d = 0;
    private int o2u = 0;
    private int o2r = 0;
    private int o2l = 0;
    private float hp = 1500;//�{�X�̍ő�HP
    private float nowhp;//�{�X�̌��݂�HP
    Rigidbody2D rb;
    private float arealr = 0.0f;//�U���͈�(���E)
    private float areaud = 0.0f;//�U���͈�(�㉺)
    GameObject Slider;
    private int counter = 0;
    private float move = 0.05f;//�{�X�̓����X�s�[�h
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        MainSpriteRendererD = enemyshotD.GetComponent<SpriteRenderer>();
        MainSpriteRendererR = enemyshotR.GetComponent<SpriteRenderer>();
        MainSpriteRendererL = enemyshotL.GetComponent<SpriteRenderer>();
        MainSpriteRendererU = enemyshotU.GetComponent<SpriteRenderer>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        Slider = GameObject.Find("Bosshp");
        script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1;//HP�o�[�𖞃^���ɂ���
        nowhp = hp;//���݂�HP���{�X��HP�Ƃ���
        Slider.SetActive(true);//HP�o�[��\������
    }

    void Update()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Vector3 p = new Vector3(move,0,0);
        transform.Translate(p);
        counter++;
        //couter��500�ɂȂ����甽�Ε����ɐi��
        if (counter == 500)
        {
            move *= -1;
        }
        //couter��1500�ɂȂ�����counter��0�ɂ��A�i�ޕ������߂�
        else if (counter == 1500)
        {
            counter = 0;
        }
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        recovery();

        //���݂�HP��0�ɂȂ����瓮�����~�߁A�摜�𔚔��ɕς��AHP�o�[�������Atag��explosion�ɕύX���A2�b���End���\�b�h�Ɉړ�����
        if (nowhp <= 0)
        {
            this.transform.position = new Vector2(x, y);
            MainSpriteRenderer.sprite = explosion;
            Slider.SetActive(false);
            this.tag = "explosion";
            Invoke("End", 2.0f);
        }
        //�v���C���[���͈͂ɓ�������ʒu�����߁A���Ԃ��v��
        else if (arealr < 60.0f && arealr > -60.0f)
        {
            if (areaud < 60.0f && areaud > -60.0f)
            {
                time1 += Time.deltaTime;
                time2 += Time.deltaTime;
                time3 += Time.deltaTime;
                //span3�b�o�߂�����enemyshotR�`enemyshotD�𐶐�
                if (time3 > span3 && this.tag != "explosion")
                {
                    Instantiate(enemyshotR);
                    Instantiate(enemyshotL);
                    Instantiate(enemyshotU);
                    Instantiate(enemyshotD);
                    enemyshotR.transform.position = new Vector2(x, y);
                    enemyshotL.transform.position = new Vector2(x, y);
                    enemyshotU.transform.position = new Vector2(x, y);
                    enemyshotD.transform.position = new Vector2(x, y);
                    time3 = 0f;
                }
                //span�b�o�߂�����enemy6r,enemy6L�̐���
                if (time1 > span && this.tag != "explosion")
                {
                    Instantiate(enemy6r);
                    Instantiate(enemy6L);
                    enemy6r.transform.position = enemy6rd.transform.position;
                    enemy6L.transform.position = enemy6lu.transform.position;
                    time1 = 0f;

                }
                //span2�b�o�߂�����enemy6l,enemy6R�̐���
                if (time2 > span2 && this.tag != "explosion")
                {
                    Instantiate(enemy6l);
                    Instantiate(enemy6R);
                    enemy6l.transform.position = enemy6ld.transform.position;
                    enemy6R.transform.position = enemy6ru.transform.position;
                    time2 = 0f;
                }
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
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
    }





    void recovery()
    {
        o2d = Random.Range(1, 11);
        //o2d�̒l��9�ȏ�Ȃ�U�����_�f�ɂ��Atag��O2�ɂ���
        if (o2d >= 9)
        {
            MainSpriteRendererD.sprite = o2up;
            enemyshotD.tag = "O2";
        }
        //����ȊO�Ȃ�U�������Atag��Boss�ɂ���
        else
        {
            MainSpriteRendererD.sprite = atk;
            enemyshotD.tag = "Boss";
        }



        o2u = Random.Range(1, 11);
        //o2u�̒l��9�ȏ�Ȃ�U�����_�f�ɂ��Atag��O2�ɂ���
        if (o2u >= 9)
        {
            MainSpriteRendererU.sprite = o2up;
            enemyshotU.tag = "O2";
        }

        //����ȊO�Ȃ�U�������Atag��Boss�ɂ���
        else
        {
            MainSpriteRendererU.sprite = atk;
            enemyshotU.tag = "Boss";
        }



        o2r = Random.Range(1, 11);
        //o2r�̒l��9�ȏ�Ȃ�U�����_�f�ɂ��Atag��O2�ɂ���
        if (o2r >= 9)
        {
            MainSpriteRendererR.sprite = o2up;
            enemyshotR.tag = "O2";
        }

        //����ȊO�Ȃ�U�������Atag��Boss�ɂ���
        else
        {
            MainSpriteRendererR.sprite = atk;
            enemyshotR.tag = "Boss";
        }



        o2l = Random.Range(1, 11);
        //o2l�̒l��9�ȏ�Ȃ�U�����_�f�ɂ��Atag��O2�ɂ���
        if (o2l >= 9)
        {
            MainSpriteRendererL.sprite = o2up;
            enemyshotL.tag = "O2";
        }

        //����ȊO�Ȃ�U�������Atag��Boss�ɂ���
        else
        {
            MainSpriteRendererL.sprite = atk;
            enemyshotL.tag = "Boss";
        }
    }

    //�N���A��ʂɈړ����A�{�X������
    void End()
    {
        SceneManager.LoadScene("Clear");
        this.gameObject.SetActive(false);
    }
}
