using UnityEngine;
using System.Collections;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField]
    float lerpMultiplier = 1f;

    [SerializeField]
    float magnitudeMultiplier = 1f;

    Transform cachedTrasform = null;
    Animator animator = null;

    Vector3 beforePosition;

    float speed = 0f;

    PlayerAIController m_playerAIController = null;

    private void Awake()
    {
        m_playerAIController = GetComponent<PlayerAIController>();
        animator = GetComponent<Animator>();
        cachedTrasform = transform;
        beforePosition = cachedTrasform.position;
    }

    private void LateUpdate()
    {
        if (beforePosition == cachedTrasform.position)
        {
			speed = Mathf.Lerp(speed, 0, lerpMultiplier);

			speed = Mathf.Clamp(speed, 0f, 1f);

			animator.SetFloat(INGAMECONST.AnimatorHash.SPEED, speed);

            return; 
        }

        Vector3 velocity = cachedTrasform.position - beforePosition;

        float magnitude = velocity.magnitude;

        magnitude *= magnitudeMultiplier;

        speed = Mathf.Lerp(speed, magnitude, lerpMultiplier);

        speed = Mathf.Clamp(speed, 0f, 1f);

        animator.SetFloat(INGAMECONST.AnimatorHash.SPEED, speed);

        beforePosition = cachedTrasform.position;
    }

    #region Animation's eventMethod

    public void NextAttack(AnimationEvent _animationEvent)
    {
        
    }

    public void DirectCamera(AnimationEvent _animationEvent)
    {
        
    }

    public void Hit(AnimationEvent _animationEvent)
    {
        int damage = _animationEvent.intParameter;
        m_playerAIController.MonAIController.HP -= damage;
    }
    #endregion
}
