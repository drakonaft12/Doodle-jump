using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CapsuleCollider _collider;
    CharacterController _characterController;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _gameObjectModel;

    float _velosityX;
    Vector2 _velosity;

    float _heigthJump = 10f;
    float _maxHeigthJump = 10f;
    float _width;

    internal float HeigthJump => _heigthJump;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _characterController = GetComponent<CharacterController>();
        _width = Camera.main.pixelWidth * Camera.main.transform.position.z / 625 / 5;
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
        if (_characterController.isGrounded || _heigthJump!=_maxHeigthJump)
        {
            _velosity.y = _heigthJump;
            _heigthJump = _maxHeigthJump;
            _animator.SetTrigger("Jump");
        }
        else { _velosity.y += -9.8f * Time.deltaTime; }

        if(_velosityX < 0) { _gameObjectModel.transform.rotation = Quaternion.EulerRotation(Vector3.up*Mathf.Deg2Rad*90); }
        else { _gameObjectModel.transform.rotation = Quaternion.EulerRotation(Vector3.up * Mathf.Deg2Rad * -90); }
        _velosity.x += _velosityX;
        _velosityX /= 2f;
        _characterController.Move(_velosity * Time.deltaTime);
        _velosity.x /= 1.05f;
        if (Camera.main.transform.position.y + Camera.main.pixelHeight * Camera.main.transform.position.z / 625 / 5 > transform.position.y)
        {
            gameObject.SetActive(false);
        }

        if (transform.position.x > -_width) 
        {
            var h = transform.position;
            h.x = _width;
            transform.position = h;
        }
        if (transform.position.x < _width)
        {
            var h = transform.position;
            h.x = -_width;
            transform.position = h;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.TryGetComponent<DestructCollision>(out var component))
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
