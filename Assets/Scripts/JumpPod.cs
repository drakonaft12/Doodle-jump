using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPod : MonoBehaviour
{
    float _height;
    private void Start()
    {
        _height = (31f / 1920 / 25) * Camera.main.pixelHeight * -Camera.main.transform.position.z / 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            player.Jump(20);
        }
    }

    private void Update()
    {
        if (Camera.main.transform.position.y - _height > transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }

}
