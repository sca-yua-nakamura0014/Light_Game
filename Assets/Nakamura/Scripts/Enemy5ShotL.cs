using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5ShotL : MonoBehaviour
{
    private float speed = 0.1f;//�U���̃X�s�[�h
    GameObject enemy4;
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
    }

    // Update is called once per frame
    void Update()
    {
        float x = enemy4.transform.position.x;//enemy4��x���W���擾����
        transform.position += new Vector3(-speed, 0.0f, 0.0f);
        //���݂�x���W��enemy4��x���W���|45�ȏ㗣��Ă�����false�ɂ���
        if (this.transform.position.x <= x - 45.0f)
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
