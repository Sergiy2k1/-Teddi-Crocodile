using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float upperLimit;



    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(3f, 2f);
    public bool isleft ;
    private Transform player;
    private int lastX;
    private void Awake()
    {
        CameraFollower();
        FindPlayer(isleft);
    }
    private void Start()
    {
        
        isleft = false;
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        
    }
    private void Update()
    {
        CameraRange();
    }
    private void FixedUpdate()
    {
        CameraFollower();
    }


    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    private void CameraFollower()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isleft = false;
            
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isleft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }


    private void CameraRange()
    {
        transform.position = new Vector3
                    (
                    Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                    Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
                    transform.position.z
                    );
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
    }
}
