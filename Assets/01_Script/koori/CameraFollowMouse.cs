using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    // 마우스 움직임에 대한 카메라 이동 속도
    [SerializeField] private float cameraSpeed = 5f;

    // 카메라 이동 제한 영역 설정 (선택 사항)
    [SerializeField] private Rect cameraLimits;

    void Update()
    {
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 카메라 이동 벡터 계산
        Vector3 targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

        // 카메라 위치를 부드럽게 업데이트
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);

        // 카메라 이동 제한 적용 (선택 사항)
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraLimits.xMin, cameraLimits.xMax),
            Mathf.Clamp(transform.position.y, cameraLimits.yMin, cameraLimits.yMax),
            transform.position.z);
    }
}
