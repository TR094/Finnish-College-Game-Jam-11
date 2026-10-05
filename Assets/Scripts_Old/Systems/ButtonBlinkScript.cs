using UnityEngine;

public class ButtonBlinkScript : MonoBehaviour
{

    public LifeSystem lifeSystem;
    public Animator animator;
    public int blinkThreshold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (lifeSystem == null) 
            lifeSystem = FindFirstObjectByType<LifeSystem>();

        if (animator == null)
            GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeSystem == null || animator == null) return;

        bool shouldBlink = lifeSystem.Lifes <= blinkThreshold;
        animator.SetBool("setBlink", shouldBlink);
    }
}
