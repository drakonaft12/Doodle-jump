using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    Player _player;
    BoxCollider[] _collider;
    void Start()
    {
        
        _collider = GetComponents<BoxCollider> ();
    }

    public void Construct(Player player)
    {
        _player = player;
    }

    private void Update()
    {
         if(_player != null)
        {
            if(transform.position.y+(transform.localScale.y)*2<=_player.transform.position.y)
            {
                foreach (var item in _collider)
                {
                    item.enabled = true;
                }
            }
            else 
            {
                foreach (var item in _collider)
                {
                    item.enabled = false;
                }
            }
        }

         if(Camera.main.transform.position.y + Camera.main.pixelHeight * Camera.main.transform.position.z / 625 /5 > transform.position.y) 
        { 
            gameObject.SetActive(false); 
        }
    }

}
