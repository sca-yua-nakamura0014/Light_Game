using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotD : MonoBehaviour
{
    
   
    private float speed = 0.05f;//�U���̃X�s�[�h
    GameObject boss;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        boss = GameObject.Find("Boss");
       
    }

    // Update is called once per frame
    void Update()
    {
       
        float x = boss.transform.position.x;//�{�X��x���W���擾
        float y = boss.transform.position.y;//�{�X��y���W���擾
        transform.position += new Vector3(0.0f, -speed, 0.0f);
        //���݂�y���W���{�X��y���W���|45�ȏ㗣��Ă�����false�ɂ���
        if (this.transform.position.y <= y - 45.0f)
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

