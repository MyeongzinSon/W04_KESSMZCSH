using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossPhase0 : Boss
{
	[SerializeField] private Boss nextBossPhase;
    [SerializeField] private int nowBossHP;
    [SerializeField] private float moveToCenterSpeed;
    [SerializeField] private string animationName;
    [SerializeField] private float delay;

    public override void OnDamage(int damage = 1)
    {
        if (!isDeal)
        {
            StartOnWeak();
        }
        StartCoroutine(nameof(StartNextPhase));
    }

    protected override int GetNextDealPatternIndex(int _currentIndex)
    {
        int result = _currentIndex;
        if (result >= dealTimePatternList.Count - 1)
        {
            result = 0;
        }
        else
        {
            ++result;
        }
        return result;
    }
    private IEnumerator StartNextPhase()
    {
        if (isDeal)
        {
            isDeal = false;
            UIManager.Instance.SetBossHP(nowBossHP);
            GameManager.instance.SetBoss(nextBossPhase.gameObject);
            ShutdownAction();
            anim.Play(animationName);
            Vector3 center = Vector3.zero;
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(delay);
            transform.DOMove(center, moveToCenterSpeed)
                .OnComplete(() =>
                {

                    nextBossPhase.transform.position = transform.position;
                    nextBossPhase.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    //nextBossPhase.Initialize();
                });
        }
    }


}
