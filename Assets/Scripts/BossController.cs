using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    private Animator animator;
    public float moveSpeed = 5f;
    public float health = 100f;
    public Transform player;
    public float attackRange = 3.0f;
    private bool isAttacking = false;
    private PlayerStats playerStats;

    void Start()
    {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            StartCoroutine(FindPlayerAfterDelay());    
    }

    // Oyuncuyu sahne yüklendikten sonra bulmaya çalış
    private IEnumerator FindPlayerAfterDelay()
    {
        // Sahne tamamen yüklendikten 1 saniye sonra player objesini arayın
        yield return new WaitForSeconds(1f);

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            Debug.Log("Player bulundu: " + player.name);
        }
        else
        {
            Debug.LogError("Player bulunamadı!");
        }

        // Player bulunduğunda başlangıç işlemlerini yap
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private IEnumerator StartAfterDelay()
    {
        Debug.Log("Sahne yüklendi, 1 saniye bekleniyor...");
        yield return new WaitForSeconds(1f); // 1 saniye bekler
        Debug.Log("Boss aktifleşti!");
        InitializeBoss();
    }

    private void InitializeBoss()
    {
        Debug.Log("Boss hazır, işlemler başlıyor...");
        // Boss'un başlatılması için gerekli diğer işlemleri buraya ekleyin
    }

    void FixedUpdate()
{
    if (player == null) return;
    if (animator == null)
    {
        Debug.LogError("Animator is null in FixedUpdate!");
        return;
    }

    Vector3 directionToPlayer = (player.position - transform.position).normalized;
    directionToPlayer.y = 0;

    float distanceToPlayer = Vector3.Distance(player.position, transform.position);
    Debug.Log("Player mesafesi: " + distanceToPlayer);

    if (distanceToPlayer > attackRange && !isAttacking)
    {
        MoveTowardsPlayer(directionToPlayer);
    }
    else if (!isAttacking)
    {
        if (gameObject.activeInHierarchy) // Make sure the GameObject is active
        {
            StartCoroutine(AttackPlayer());
        }
    }
}

    private void MoveTowardsPlayer(Vector3 directionToPlayer)
    {
        animator.SetFloat("speed", 1);
        float targetAngle = Mathf.Atan2(directionToPlayer.x, directionToPlayer.z) * Mathf.Rad2Deg;
        float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        Vector3 move = transform.forward * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
        Debug.Log("Boss hareket ediyor...");
    }

    private IEnumerator AttackPlayer()
    {
        if (animator == null)
        {
            Debug.LogError("Animator is null in AttackPlayer!");
            yield break;
        }

        isAttacking = true;
        animator.SetFloat("speed", 0);

        Debug.Log("Animation State before attack: " + animator.GetCurrentAnimatorStateInfo(0).fullPathHash);

        if (Random.value > 0.5f)
        {
            animator.SetTrigger("NormalAttack");
            Debug.Log("Boss Normal Saldırı Yapıyor.");
        }
        else
        {
            animator.SetTrigger("PowerAttack");
            Debug.Log("Boss Güçlü Saldırı Yapıyor.");
        }

        yield return new WaitForSeconds(2f);
        isAttacking = false;
        Debug.Log("Boss tekrar saldırmaya hazır.");
    }

    public void DealDamage()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= attackRange)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(10f);
                Debug.Log("Player saldırıdan hasar aldı!");
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Boss hasar aldı: {damage}. Kalan can: {health}");

        if (health <= 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            animator.SetTrigger("Die");
            Debug.Log("Boss öldü.");
        }
    }
}


