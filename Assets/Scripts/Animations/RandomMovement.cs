using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f; // 이동 속도
    public Vector2 moveRangeX = new Vector2(-2, 3); // X축 이동 범위
    public Vector2 moveRangeY = new Vector2(-1, 1); // Y축 이동 범위
    public float rotationSpeed = 1.0f; // 회전 속도

    private Vector3 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(moveRangeX.x, moveRangeX.y);
        float randomY = Random.Range(moveRangeY.x, moveRangeY.y);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // if (direction != Vector3.zero)
        // {
        //     // y축 회전만을 적용하기 위해 방향을 계산
        //     Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        //     toRotation = Quaternion.Euler(0, toRotation.eulerAngles.y, 0); // y축 회전만을 설정
        //     transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        // }

        // 목표 위치에 도달하면 새로운 목표 위치 설정
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }
}
