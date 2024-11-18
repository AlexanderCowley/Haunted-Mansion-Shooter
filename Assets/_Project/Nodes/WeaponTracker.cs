using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTracker : MonoBehaviour
{
    [SerializeField] float RotSpeed;
    [SerializeField] float OffSetX;
    float OffSetY = 0f;
    Transform _parentTransform;

    Vector3 turn;
    Camera _camera;
    void Awake() 
    {
        _parentTransform = GetComponentInParent<Transform>();
        _camera = Camera.main;
        turn = new();
    }

    void Update() 
    {
        //Might need to reset input after 
        turn.x += Input.GetAxis("Mouse X") * 
            RotSpeed * Time.deltaTime + OffSetX;
        turn.y += Input.GetAxis("Mouse Y") * 
            RotSpeed * Time.deltaTime + OffSetY;
        
        //Limits the turn values
        turn.x = Mathf.Clamp(turn.x, -35, 35);
        turn.y = Mathf.Clamp(turn.y, -35, 35);
        Quaternion target = Quaternion.Euler(
            -turn.y, turn.x, 0);
        transform.localRotation = target;
        
    }
}
