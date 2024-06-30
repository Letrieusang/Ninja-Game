using System;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
        [SerializeField] private string initState;
        [SerializeField] private FSMState[] states;
        public FSMState currentState { get; set; }

        private void Start()
        {
                ChangeState(initState);
        }
        private void Update()
        {
                currentState?.UpdateState(this);
        }

        public void ChangeState(string newStateId)
        {
                FSMState newState = GetState(newStateId);
                if (newState != null)
                {
                        currentState = newState;
                }

                return;
        }

        private FSMState GetState(string newStateId)
        {
                for (int i = 0; i < states.Length; i++)
                {
                        if (states[i].Id == newStateId)
                        {
                                return states[i];
                        }
                }

                return null;
        }

        
}
