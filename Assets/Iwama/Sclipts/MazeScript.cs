using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeScript : MonoBehaviour
{
    public GameObject[] Maze;//�����_���ŕ\����������H

    void Start()
    {
       int  number = Random.Range(0, Maze.Length);
       Instantiate(Maze[number], new Vector3(1f,0f,0.0f),Quaternion.identity);
    }
       
 }
        
