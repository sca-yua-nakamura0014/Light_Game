using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    //���ʉ�
    public GameObject gunSound;

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
        //�v���C���[�Ɏ擾���������
        if (other.gameObject.tag == "Player")
        {
            Instantiate(gunSound, this.transform.position, this.transform.rotation);//���ʉ�
            Destroy(gameObject);
        }

    }


}
