//匀速移动
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    bool flag = false;
    float speed;
    Vector3 startpos;
    Vector3 endpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = gameObject.transform.position;
        endpos = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Move(gameObject,startpos,endpos,2f,false);
    }
    void Move(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        speed = Vector3.Distance(begin, end) / time;
        float step = speed * Time.deltaTime;
        if(!pingpong)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, end, step);
        }
        if(pingpong)
        {
            if(!flag)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, end, step);
            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,begin, step);
            }
            if (Mathf.Abs(Vector3.Distance(gameObject.transform.position, begin)) < 0.1f && flag == true) flag = false;
            if (Mathf.Abs(Vector3.Distance(gameObject.transform.position, end)) < 0.1f && flag == false) flag = true;
        }
    }
}
