using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    GameObject enemy4;
    Rigidbody2D rb;
    private float Speed = 30;//�U���̑���
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        enemy4 = GameObject.Find("Enemy4");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̕����ֈړ�����
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.transform.position.x, player.transform.position.y), Speed * Time.deltaTime);
        //enemy4��x���W���40�ȏ�܂���40�ȉ��A�����W���40�ȏ�܂���40�ȉ��Ȃ�false�ɂ���
        if (this.transform.position.x > enemy4.transform.position.x + 45.0f || this.transform.position.x < enemy4.transform.position.x - 45.0f || this.transform.position.y > enemy4.transform.position.y + 45.0f || this.transform.position.y < enemy4.transform.position.y - 45.0f)
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
