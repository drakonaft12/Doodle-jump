using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    BoxCollider _collider;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _gameObjectModel;

    float _velosityX;
    Vector2 _velosity;

    float _heigthJump = 10f;
    float _maxHeigthJump = 10f;
    float _width;
    float _height;
    bool _jump = false;

    internal float HeigthJump => _heigthJump;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _width = (16.4f / 1080 / 25) * Camera.main.pixelWidth* -Camera.main.transform.position.z / 2;
        _height = (31f / 1920 / 25) * Camera.main.pixelHeight * -Camera.main.transform.position.z /2;

    }

    public void Move(float move)
    {
        _velosityX = move;
    }

    public void Jump(float heigth) 
    {
        _heigthJump = heigth;
        
    }

    private void Update()
    {
        MoveUpdate();
        if (Camera.main.transform.position.y - _height > transform.position.y)
        {
            gameObject.SetActive(false);
        }

        if (transform.position.x < -_width)
        {
            var h = transform.position;
            h.x = _width;
            transform.position = h;
        }
        if (transform.position.x > _width)
        {
            var h = transform.position;
            h.x = -_width;
            transform.position = h;
        }
    }

    private void MoveUpdate()
    {
        
        if (_velosity.y<0)
        {
            _collider.enabled = true;
        }
        else { _collider.enabled = false;}
        if (_jump || _heigthJump != _maxHeigthJump)
        {
            _velosity.y = _heigthJump;
            _heigthJump = _maxHeigthJump;
            _animator.SetTrigger("Jump");
            _jump = false;
        }
        else { _velosity.y += -9.8f * Time.deltaTime; }

        if (_velosityX < -0.01f) { _gameObjectModel.transform.rotation = Quaternion.EulerRotation(Vector3.up * Mathf.Deg2Rad * 90); }
        else { _gameObjectModel.transform.rotation = Quaternion.EulerRotation(Vector3.up * Mathf.Deg2Rad * -90); }

        _velosity.x += _velosityX;
        _velosityX /= 2f;
        transform.position +=(Vector3) _velosity * Time.deltaTime;
        _velosity.x /= 1.05f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _jump = true;
        if(collision.gameObject.TryGetComponent<DestructCollision>(out var component))
        {
            component.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
