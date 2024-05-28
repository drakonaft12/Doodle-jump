using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPod : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            player.Jump(20);
        }
    }

    private void Update()
    {
        if (Camera.main.transform.position.y + Camera.main.pixelHeight * Camera.main.transform.position.z / 625 / 5 > transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }

}
