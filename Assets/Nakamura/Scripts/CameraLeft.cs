using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeft : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite eye;//�ڂ����Ă�G�摜
    [SerializeField] private Sprite enemy3;//�ڂ��J���Ă�G�摜
    [SerializeField] private GameObject enemy4;//�o��������G
    private float time = 0f;
    private int sleep = 3;//�摜�؂�ւ��̊Ԋu
    private int en = 0;//�������ꂽ�G�̐�
    private float arealr = 0.0f;//�J�����͈̔�(�㉺)
    private float areaud = 0.0f;//�J�����͈̔�(���E)
    Rigidbody2D rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //�b��/10�̗]�肪sleep��菬�����Ȃ�ڂ��J��
        if(time%10 <=sleep)
        {
            MainSpriteRenderer.sprite = enemy3;

        }
        //����ȊO�Ȃ����
        else
        {
            MainSpriteRenderer.sprite = eye;
        }

        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //�v���C���[��x���W���[�P�ȏ�26�ȉ�����y���W���|15�ȏ�15�ȉ��Ȃ�
        if (arealr < 26.0f && arealr > -1.0f)
        {
            if (areaud < 15.0f && areaud > -15.0f)
            {
                float x = this.transform.position.x+3;
                float y = this.transform.position.y;
                //�ڂ��J���Ă邩�G����������Ă��Ȃ��Ȃ�G�𐶐����Aen��+1����
                if (MainSpriteRenderer.sprite == enemy3 && en < 1)
                {
                    GetComponent<AudioSource>().Play();
                    Instantiate(enemy4);
                    enemy4.transform.position = new Vector2(x, y);
                    en++;
                }

                //�ڂ������Ȃ琶�����ꂽ�G�̐���0�ɖ߂�
                if (MainSpriteRenderer.sprite == eye)
                {
                    en = 0;
                }
            }

        }
    }
}
