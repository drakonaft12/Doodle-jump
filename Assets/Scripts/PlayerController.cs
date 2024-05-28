using UnityEngine;

[RequireComponent (typeof(Player))]
public class PlayerController : MonoBehaviour
{
    Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void Update()
    {
#if RENDER_SOFTWARE_CURSOR
        if (Input.GetKey(KeyCode.A))
        {
            _player.Move(-1);
        }

        if(Input.GetKey(KeyCode.D)) 
        { 
            _player.Move(1); 
        }
#else
_player.Move(Input.acceleration.x);
#endif
    }
}
