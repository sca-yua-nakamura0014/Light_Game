using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Control : MonoBehaviour
{
    //�ʏ��

    public GameObject attackUpBook;
    public GameObject attackSpeedBook;
    public GameObject defenseBook;
    public GameObject attackRangeBook;
    public GameObject speedBook;

    public GameObject stone;

    private bool decision = true;//�h���b�v�A�C�e���m��܂ł̔���

    //���ʉ�
    public GameObject openSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
           Drop1();

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Drop1();

        }

    }

    private void Stone()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(stone, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        }


    }

    public void Drop1()
    {
        Instantiate(openSound, this.transform.position, this.transform.rotation);//���ʉ�
        Destroy(gameObject);

        int i = 0;//while�������[�v���邽�߂̏���
        while (decision = true)
        {
            float rnd = Random.Range(0, 1f);

            //�U���͈�UP�𔃂��Ă��Ȃ��Ȃ�h���b�v����0�ɐݒ�
            if (book2.shopRange == false)
            {
                GameManager.attackRange = 0;
            }
            //�h���UP�𔃂��Ă��Ȃ��Ȃ�h���b�v����0�ɐݒ�
            if (book1.shopDefense == false)
            {
                GameManager.defenseUp = 0;
            }

            //���ׂĂ̋����{�̃h���b�v��������𒴂����玑���𗎂Ƃ�
            if (GameManager.attackUp == 0 && GameManager.attackSpeedUp == 0 && GameManager.speedUp == 0 && GameManager.attackRange == 0 && GameManager.defenseUp == 0)
            {
                Stone();
                break;
            }
            //�U����UP�h���b�v
            if (rnd <= 0.3f)
            {
                if (GameManager.attackUp > 0)
                {
                    Instantiate(attackUpBook, this.transform.position, this.transform.rotation);
                    GameManager.attackUp -= 1;
                    break;

                }
                else { i += 1; }//while�������[�v���邽�߂̏���

            }
            //�U�����xUP�h���b�v
            else if (rnd <= 0.5f)
            {
                if (GameManager.attackSpeedUp > 0)//�h���b�v����������ĂȂ���Ύ��s
                {
                    Instantiate(attackSpeedBook, this.transform.position, this.transform.rotation);
                    GameManager.attackSpeedUp -= 1;
                    break;
                }
                else { i += 1; }
            }
            //�ړ����xUP�h���b�v
            else if (rnd <= 0.7f)
            {
                if (GameManager.speedUp > 0)//�h���b�v����������ĂȂ���Ύ��s
                {
                    Instantiate(speedBook, this.transform.position, this.transform.rotation);
                    GameManager.speedUp -= 1;
                    break;
                }
                else { i += 1; }
            }
            //�U���͈�UP�h���b�v
            else if (rnd <= 0.8f)
            {
                if (book2.shopRange == true)//�V���b�v�ōw�����Ă���Ύ��s
                {
                    if (GameManager.attackRange > 0)//�h���b�v����������ĂȂ���Ύ��s
                    {
                        Instantiate(attackRangeBook, this.transform.position, this.transform.rotation);
                        GameManager.attackRange -= 1;
                        break;
                    }
                    else { i += 1; }
                }
            }
            //�h���UP�h���b�v
            else
            {
                if (book1.shopDefense == true)//�V���b�v�ōw�����Ă���Ύ��s
                {
                    if (GameManager.defenseUp > 0)//�h���b�v����������ĂȂ���Ύ��s
                    {
                        Instantiate(defenseBook, this.transform.position, this.transform.rotation);
                        GameManager.defenseUp -= 1;
                        break;
                    }
                    else { i += 1; }
                }
            }


        }
    }
}
