using UnityEngine;
using System;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyNPC))]

public class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemySO _EnemySO;
    [SerializeField] private EnemyNPC _enemy;

    //public int MaxHealth = 100;
    public event EventHandler OnTakeHit;

    private int _CurrentHealth;
    private bool OnDeath = false; 
    private PolygonCollider2D _AttackCollider;
    private SpriteRenderer _SpriteRenderer;


    void Start()
    {
        _CurrentHealth = _EnemySO.EnemyHealth;

        _AttackCollider = GetComponent<PolygonCollider2D>();
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Boom");
    }

    public bool GetOnDeath()
    {
        return OnDeath;
    }

    public void TakeDamage(int damage)
    {
        _CurrentHealth -= damage;
        OnTakeHit?.Invoke(this, EventArgs.Empty);
        DetectDeath();
    }

    public void ActiveateAttackCollider()
    {
        _AttackCollider.enabled = true;
    }

    public void DeactiveateAttackCollider()
    {
        _AttackCollider.enabled = false;
    }

    void DetectDeath()
    {
        if (_CurrentHealth <= 0)
        {
            _AttackCollider.enabled = false;
            OnDeath = true;
            _enemy.ActivateDeath();
            _SpriteRenderer.sortingOrder = -1;
            //Destroy(gameObject);
        } 
    }



    


}
