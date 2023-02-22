using UnityEngine;

namespace Controllers
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private Animator moneyAnim;
        public void Collect(Transform playerTransform, float moneyOffset)
        {
            transform.parent = playerTransform;
            transform.localPosition = Vector3.zero + (moneyOffset * Vector3.up);
            moneyAnim.enabled = false;
            moneyAnim.transform.localRotation = Quaternion.identity;
            
        }
        
    }
}