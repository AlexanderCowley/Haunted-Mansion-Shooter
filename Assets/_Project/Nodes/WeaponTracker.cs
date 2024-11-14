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
        turn.x += Input.GetAxisRaw("Mouse X") * RotSpeed * Time.deltaTime;
        turn.y += Input.GetAxisRaw("Mouse Y") * RotSpeed * Time.deltaTime;

        Quaternion target = Quaternion.Euler(
            Mathf.Clamp(-turn.y + OffSetY, 0f, 35f), 
            Mathf.Clamp(turn.x + OffSetX, 0f, 35f), 0);
        transform.localRotation = target;
    }
}
