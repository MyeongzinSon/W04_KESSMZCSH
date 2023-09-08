using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInfo : MonoBehaviour
{
    [Header("General")]
    [SerializeField] protected float speedMuptiplier;
    [SerializeField] protected float actionDuration;
    [SerializeField] protected bool canRollCancelAction;
    [SerializeField] protected bool canActionCancelRoll;

    protected PlayerController player;

    public float SpeedMultiplier => speedMuptiplier;
    public float ActionDuration => actionDuration;
    public bool CanRollCancelAction => canRollCancelAction;
    public bool CanActionCancelRoll => canActionCancelRoll;

    public abstract bool CanAction { get; }

    protected virtual void Awake()
    {
        player = transform.parent.GetComponent<PlayerController>();
    }
    protected virtual void Start()
    {

    }

    public virtual void OnStartAction()
    {
    }
    public virtual void OnUpdateAction()
    {

    }
    public virtual void OnUpdateNotAction()
    {

    }
    public virtual void OnEndAction()
    {

    }
}