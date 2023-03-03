using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoxControle : MonoBehaviour
{
    //�W�����vUP�m���

    public GameObject jumpUpBook;

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
            Instantiate(openSound, this.transform.position, this.transform.rotation);//���ʉ�
            Destroy(gameObject);

            Instantiate(jumpUpBook, this.transform.position, this.transform.rotation);//�W�����vUP
            
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(openSound, this.transform.position, this.transform.rotation);//���ʉ�
            Destroy(gameObject);

            Instantiate(jumpUpBook, this.transform.position, this.transform.rotation);//�W�����vUP

        }

    }
}
