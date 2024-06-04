using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    float _height;
    float positionYCamera => Camera.main.transform.position.y;
    void Start()
    {
        _height = (31f / 1920 / 25) * Camera.main.pixelHeight * -Camera.main.transform.position.z / 2;

    }


    private void Update()
    {

        if (positionYCamera - _height > transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
