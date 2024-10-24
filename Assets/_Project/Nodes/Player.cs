using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour, IShootable
{
    [Header("Node Stats")]
    [SerializeField] Node TargetNode;
    public bool InputEnabled = true;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotationSpeed;

    [Header("Weapons")]
    [SerializeField] Weapon CurrentWeapon;
    public int CurrentHealth {get; private set;}
    [SerializeField] int MaxHealth;

    [Header("Cursor")]
    [SerializeField] Texture2D CursorTexture;

    [Header("Audio")]
    [SerializeField] AudioSource _audioSource;

    Rails _manager;

    public delegate void OnDamageTaken();
    public event OnDamageTaken DamageTakenHandler;
    public event OnDamageTaken WeaponFiredHandler;

    void Awake() 
    {
        _manager = FindAnyObjectByType<Rails>();
        Time.timeScale = 1f;
        Cursor.SetCursor(CursorTexture, new Vector2(64,64), CursorMode.ForceSoftware);
        CurrentHealth = MaxHealth;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
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

    //Passing in node entered
    public void SetNode(Node CurrentNode)
    {
        if(CurrentNode == null) return;
        MoveSpeed = CurrentNode.MoveSpeed;
        RotationSpeed = CurrentNode.RotationSpeed;
        TargetNode = CurrentNode.NextNode;
        InputEnabled = CurrentNode.ActiveInput;
    }

    public void TakeDamage(int damageTaken)
    {
        CurrentHealth -= damageTaken;
        DamageTakenHandler?.Invoke();
        if(CurrentHealth <= 0)
        {
            _manager.GameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Update() 
    {
        //Target nodes should not be null
        //If they do it should be the end of the stage
        if(TargetNode == null) 
        {
            _audioSource.Stop(); 
            return;
        }
        Move();
        Rotate();
        if(!InputEnabled) return;
        if(Input.GetMouseButtonDown(0))
        {
            CurrentWeapon.Fire();
            WeaponFiredHandler?.Invoke();
        }
    }

}
