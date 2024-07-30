using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    // ���콺 �����ӿ� ���� ī�޶� �̵� �ӵ�
    [SerializeField] private float cameraSpeed = 5f;

    // ī�޶� �̵� ���� ���� ���� (���� ����)
    [SerializeField] private Rect cameraLimits;

    void Update()
    {
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ī�޶� �̵� ���� ���
        Vector3 targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

        // ī�޶� ��ġ�� �ε巴�� ������Ʈ
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);

        // ī�޶� �̵� ���� ���� (���� ����)
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraLimits.xMin, cameraLimits.xMax),
            Mathf.Clamp(transform.position.y, cameraLimits.yMin, cameraLimits.yMax),
            transform.position.z);
    }
}
