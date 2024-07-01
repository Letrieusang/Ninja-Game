using System;
using UnityEngine;

public class DamageManager : MonoBehaviour
{

    public static DamageManager Instance;     
    
        [SerializeField] private DamageText damageTextPrefab;

        private void Awake()
        {
            Instance = this;
        }

        public void ShowDamageText(float damageAmount, Transform target)
        {
              DamageText text =  Instantiate(damageTextPrefab, target);
              text.transform.position += Vector3.right * 13.5f;
              text.SetDamageText(damageAmount);
        }
}
