using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Shot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshotR;//�U��(�E)
    [SerializeField] private GameObject enemyshotL;//�U��(��)
    [SerializeField] private GameObject enemyshotU;//�U��(��)
    [SerializeField] private GameObject enemyshotD;//�U��(��)
    [SerializeField] private GameObject Shot;//�U��(�ǐ�)
    GameObject player;
    GameObject enemy4;
    private float span = 5.0f;//enemyshotR�`enemyshotD������������Ԋu
    private float span2 = 8.0f;//Shot�����������Ԋu
    private float time = 0f;
    private float time2 = 0f;
    private float arealr = 0.0f;//�U���͈�(���E)
    private float areaud = 0.0f;//�U���͈�(�㉺)
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //�v���C���[���͈͓��ɓ������玞�Ԃ��v��
        if (arealr < 50.0f && arealr > -50.0f)
        {
            if (areaud < 50.0f && areaud > -50.0f)
            {
                float x = enemy4.transform.position.x;
                float y = enemy4.transform.position.y;
                time += Time.deltaTime;
                time2 += Time.deltaTime;
                //span�b�o�߂�����enemyshotR�`enemyshotD�𐶐�
                if (time > span)
                {
                    Instantiate(enemyshotR);
                    Instantiate(enemyshotL);
                    Instantiate(enemyshotU);
                    Instantiate(enemyshotD);
                    enemyshotR.transform.position = new Vector2(x, y);
                    enemyshotL.transform.position = new Vector2(x, y);
                    enemyshotU.transform.position = new Vector2(x, y);
                    enemyshotD.transform.position = new Vector2(x, y);
                    time = 0f;
                }
                //span2�b�o�߂�����shot�𐶐�
                if (time2 % 10 > span2)
                {
                    Instantiate(Shot);
                    Shot.transform.position = new Vector2(x, y);
                    time2 = 0f;
                }
               

            }
        }


    }


}