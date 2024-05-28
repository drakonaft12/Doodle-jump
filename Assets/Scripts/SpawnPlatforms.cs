using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField] Player player;
    Vector2 spawnPosition;

    float _heigthVoid = 0.3f;
    float _width;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        _width = (Camera.main.pixelWidth * Camera.main.transform.position.z / 625 / 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y - Camera.main.pixelHeight * Camera.main.transform.position.z / 625 / 5f > spawnPosition.y)
        {
            bool isDestructPlatform = Random.Range(0, 2) == 0;
            spawnPosition.x = Random.Range(-_width, _width);
            spawnPosition.y += _heigthVoid;
            _heigthVoid += _heigthVoid < player.HeigthJump / 2 - 0.5f ? 0.05f : 0;
            var item = Spawner.me.Spawn(isDestructPlatform ? 3 : 1, spawnPosition);
            item.GetComponent<Platform>().Construct(player);
            if (Random.Range(0, 20) == 0&&!isDestructPlatform)
            {
                Spawner.me.Spawn(2, spawnPosition + Vector2.right * Random.Range(-1f, 1f) + Vector2.up * 0.5f);
            }
        }
    }
}
