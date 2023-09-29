using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoombie : MonoBehaviour
{
    [SerializeField] GameObject m_Zoombie;
    [SerializeField] private float timeWait;
    [SerializeField] private Transform atractpoint;
    float timer;
    // Update is called once per frame
    void Update()
    {  
            timer += Time.deltaTime;
            if (timer > timeWait)
            {
                timer = 0;
                GameObject newZoombie = Instantiate(m_Zoombie, atractpoint.position, Quaternion.identity);
            }
    }
}
