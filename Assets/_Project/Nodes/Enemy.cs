using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyNode TargetNode;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotationSpeed;
    [SerializeField] int Damage;
    Animator _animator;
    AudioSource _audioSource;
    bool _isAttacking = false;

    Rails Manager;

    void OnEnable() 
    {
        Manager = FindAnyObjectByType<Rails>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if(TargetNode == null) return;
        transform.position = TargetNode.transform.position;
        transform.rotation = TargetNode.transform.rotation;
        SetNode(TargetNode);
    }
    //Passing in node entered
    public void SetNode(EnemyNode CurrentNode)
    {
        if(CurrentNode == null) return;
        MoveSpeed = CurrentNode.MoveSpeed;
        RotationSpeed = CurrentNode.RotationSpeed;
        TargetNode = CurrentNode.NextNode;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            TargetNode.transform.position, MoveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            TargetNode.transform.rotation, RotationSpeed * Time.deltaTime);
    }

    public void PlayAnimation(string clip)
    {
        _animator.Play(clip, -1, 0f);
        if(clip == "Attack")
        {
            _isAttacking = true;
            _audioSource.Play();
        }
    }

    bool IsAnimPlaying(string clip)
    {
    return _animator.GetCurrentAnimatorStateInfo(0).length > 
        _animator.GetCurrentAnimatorStateInfo(0).normalizedTime
        && _animator.GetCurrentAnimatorStateInfo(0).IsName(clip);
    }

    void Update() 
    {
        if(_isAttacking && 
            _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f)
        {
            Manager.player.TakeDamage(Damage);
            _isAttacking = false;
        }
        if(TargetNode == null) return;
        Move();
        Rotate();
        
    }
}
