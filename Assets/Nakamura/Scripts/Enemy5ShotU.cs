using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5ShotU : MonoBehaviour
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
        float y = enemy4.transform.position.y;//enemy4��y���W���擾����
        transform.position += new Vector3(0.0f,speed, 0.0f);
        //���݂�y���W��enemy4��y���W���45�ȏ㗣��Ă�����false�ɂ���
        if (this.transform.position.y >= y + 45.0f)
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
