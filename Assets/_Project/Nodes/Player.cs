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

    [Header("Health")]
    int _currentHealth;
    [SerializeField] int MaxHealth = 10;

    [Header("Cursor")]
    [SerializeField] Texture2D CursorTexture;

    void Awake() 
    {
        Cursor.SetCursor(CursorTexture, new Vector2(64,64), CursorMode.ForceSoftware);
        _currentHealth = MaxHealth;
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
        _currentHealth -= damageTaken;
    }

    void Update() 
    {
        //Target nodes should not be null
        //If they do it should be the end of the stage
        if(TargetNode == null) return;
        Move();
        Rotate();
        if(!InputEnabled) return;
        if(Input.GetMouseButtonDown(0))
        {
            CurrentWeapon.Fire();
        }
    }

}
