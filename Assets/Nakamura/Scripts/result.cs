using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("move",5.0f);//5�b���move���\�b�h�����s����
    }

    // Update is called once per frame
    void move()
    {
        SceneManager.LoadScene("result");//result�ֈړ�
    }
}
