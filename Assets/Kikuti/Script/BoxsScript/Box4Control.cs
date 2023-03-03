using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box4Control : MonoBehaviour
{
    //���A��

    public GameObject hpUpBook;
    public GameObject o2UpBook;
    public GameObject hpRecoveryBook;

    public GameObject stone;

    private bool decision = true; //�h���b�v�A�C�e���m��܂ł̔���

    //�J�����ʉ�
    public GameObject openSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Drop4();   
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Drop4();
        }
    }

    private void Stone()
    {
        for(int i=0;i<10;i++)
        {
            Instantiate(stone, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), this.transform.rotation);
        }
        

    }

    public void Drop4()
    {
        Instantiate(openSound, this.transform.position, this.transform.rotation);//���ʉ�
        Destroy(gameObject);

        int i = 0; //while�������[�v���邽�߂̏���
        while (decision == true)
        {

            float rnd = Random.Range(0, 1f);

            //HP�����񕜂𔃂��Ă��Ȃ��Ȃ�h���b�v����0�ɐݒ�
            if (book3.shopRec == false)
            {
                GameManager.hpRecUp = 0;
            }
            //���ׂĂ̋����{�̃h���b�v��������𒴂����玑���𗎂Ƃ�
            if (GameManager.hpUp == 0 && GameManager.o2Up == 0 && GameManager.hpRecUp == 0)
            {
                Stone();
                break;
            }
            //HPUP�h���b�v
            if (rnd <= 0.3f)
            {
                if (GameManager.hpUp > 0)//�h���b�v����������ĂȂ���Ύ��s
                {
                    Instantiate(hpUpBook, this.transform.position, this.transform.rotation);
                    GameManager.hpUp -= 1;
                    decision = false;
                }
                else { i += 1; }//while�������[�v���邽�߂̏���

            }
            //�_�f�������h���b�v
            else if (rnd <= 0.6f)
            {
                if (GameManager.o2Up > 0)//�h���b�v����������ĂȂ���Ύ��s
                {
                    Instantiate(o2UpBook, this.transform.position, this.transform.rotation);
                    GameManager.o2Up -= 1;
                    decision = false;
                }
                else { i += 1; }
            }
            //�����񕜃h���b�v
            else
            {
                if (book3.shopRec == true)//�V���b�v�ōw�����Ă���Ύ��s
                {
                    if (GameManager.hpRecUp > 0)//�h���b�v����������ĂȂ���Ύ��s
                    {
                        Instantiate(hpRecoveryBook, this.transform.position, this.transform.rotation);
                        GameManager.hpRecUp -= 1;
                        decision = false;
                    }
                    else { i += 1; }
                }
            }
        }
    }
    
}
