using UnityEngine;

namespace GetNoodie
{
    [RequireComponent(typeof(Animator))]
    public class DestroyOnEnd : MonoBehaviour
    {
        private Animator anim;
        // Start is called before the first frame update
        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        // Update is called once per frame
        private void Update()
        {
            var info = anim.GetCurrentAnimatorStateInfo(0);
            if (info.normalizedTime >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}