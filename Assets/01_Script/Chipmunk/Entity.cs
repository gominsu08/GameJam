using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
public class Entity : MonoBehaviour
{
    [SerializeField] protected float _speed = 1f;
    [SerializeField] protected float _moveSpace = 1f;
    protected CommandInvoker commandInvoker { get => CommandManager.Instance.commandInvoker; }
    [SerializeField] protected UnityEvent<Vector2> OnMoveEvent;
    [SerializeField] private UnityEvent OnDeathEvent;
    [field: SerializeField] public Transform _visualTrm { get; protected set; }
    public bool isMoveing { get; protected set; }
    protected virtual void Awake()
    {
        if (_visualTrm == null)
            _visualTrm = transform.Find("Visual");
        if (!Grid.Instance.set(this, transform.position))
            Debug.Log($"entity : {transform.position}좌표에 이미 벽이 있습니다!");
    }
    protected virtual void OnDestroy()
    {
        OnDeathEvent?.Invoke();
        Grid.Instance.remove(transform.position);
    }
    private void Update()
    {
    }
    public virtual void Move(Vector2 direction)
    {
        if (isMoveing) return;
        isMoveing = true;
        Vector2 targetPosition = (Vector2)transform.position + direction;
        Command command;
        // if (Physics2D.RaycastAll(transform.position, direction, direction.magnitude).ToList().Any((a) => a.transform != transform))
        if (!Grid.Instance.set(this, targetPosition))
        {
            if (Grid.Instance.entityDic.TryGetValue(Vector2Int.RoundToInt(targetPosition), out Entity targetEntity))
            {
                IEnumerator waiter()
                {
                    yield return null;
                    targetEntity.OnMoveEvent.RemoveListener(OnTargetMove);
                    command = new BlockCommand(this, 1 / _speed);
                    command.onCompleteAction += () => isMoveing = false;
                    commandInvoker.ExecuteCommand(command);
                }
                Coroutine coroutine = null;
                coroutine = StartCoroutine(waiter());
                void OnTargetMove(Vector2 pos)
                {
                    Debug.Log("밍밍");
                    isMoveing = false;
                    Move(direction);
                    targetEntity.OnMoveEvent.RemoveListener(OnTargetMove);
                    StopCoroutine(coroutine);
                }

                targetEntity.OnMoveEvent.AddListener(OnTargetMove);
                targetEntity.OnMoveEvent.AddListener(a => Debug.Log("밍"));
            }
            else
            {
                command = new BlockCommand(this, 1 / _speed);
                command.onCompleteAction += () => isMoveing = false;
                commandInvoker.ExecuteCommand(command);
            }
        }
        else
        {
            Grid.Instance.remove(transform.position);
            OnMoveEvent?.Invoke(targetPosition);
            command = new MoveCommand(this, 1 / _speed, targetPosition);
            command.onCompleteAction += () => isMoveing = false;
            commandInvoker.ExecuteCommand(command);
        }
    }
    IEnumerator a()
    {
        yield return null;
    }
}
