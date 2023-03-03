using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshot;
    GameObject player;
    private float span = 2.0f;//shot������������Ԋu
    private float time =0f;
    private float arealr = 0.0f;//�U���͈�(���E)
    private float areaud = 0.0f;//�U���͈�(�㉺)
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //Debug.Log(arealr);
        //�v���C���[���͈͓��ɓ������玞�Ԃ��v��
        if (arealr<80.0f &&  arealr>-80.0f)
        {
            if (areaud < 20.0f && areaud > -20.0f)
            {
                float x = this.transform.position.x;
                float y = this.transform.position.y;
                time += Time.deltaTime;
                //span�b�o�߂����琶��
                if (time > span)
                {
                    Instantiate(enemyshot);
                    enemyshot.transform.position = new Vector2(x - 0.7f, y - 0.8f);
                    time = 0f;
                }
            }
        }
    }
}
