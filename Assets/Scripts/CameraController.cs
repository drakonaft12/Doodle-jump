using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Player _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< _player.transform.position.y)
        {
            var vec = transform.position;
            vec.y = Mathf.Lerp(vec.y, _player.transform.position.y, Time.deltaTime*2);
            transform.position = vec;
        }
    }
}
