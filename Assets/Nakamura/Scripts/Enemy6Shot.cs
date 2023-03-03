using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Shot : MonoBehaviour
{
    private GameObject enemy6l;
    private GameObject enemy5;
    private float speed = 0.0009f;//�U���X�s�[�h
    float right;
    float up;
    // Start is called before the first frame update
    void Start()
    {
        enemy6l = GameObject.Find("Enemy6ShotLh");
        enemy5 = GameObject.Find("Enemy5");
        //�������ꂽ�ʒu��x���W��enemy5��x���W���傫���Ȃ�+�����ɔ�΂�
        if (this.transform.position.x >= enemy5.transform.position.x)
        {
            right = (this.transform.position.x * 2) * speed;
        }
        //����ȊO�Ȃ�-�����ɔ�΂�
        else
        {
            right = (this.transform.position.x * -2) * speed;
        }

        //�������ꂽ�ʒu�̂����W��enemy5��x���W���傫���Ȃ�]�����ɔ�΂�
        if (this.transform.position.y >= enemy5.transform.position.y)
        {
            up= (this.transform.position.y * -2) * speed;
            
        }
        //����ȊO�Ȃ�+�����ɔ�΂�
        else
        {
            up = (this.transform.position.y * 2) * speed;
        }


    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-right, -up, 0.0f);
        float x = enemy6l.transform.position.x;//�������ꂽ�ꏊ��x���W���擾
        float y = enemy6l.transform.position.y;//�������ꂽ�ꏊ��y���W���擾
        //�I�u�W�F�N�g�̈ʒu���������ꂽ�ꏊ��x���W���40�ȏ�܂���40�ȉ��A�����W���40�ȏ�܂���40�ȉ��Ȃ�false�ɂ���
        if (this.transform.position.x >= x + 40.0f || this.transform.position.x <= x - 40.0f || this.transform.position.y >= y + 40.0f || this.transform.position.y <= y - 40.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet�APlayer�AWall�APartner�ADoor�̂ǂꂩ�ɓ��������Ȃ�false�ɂ���
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Partner" || other.gameObject.tag == "Door")
        {
            this.gameObject.SetActive(false);
        }
    }
}
