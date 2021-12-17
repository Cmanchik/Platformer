using System.Linq;
using UnityEngine;

namespace SystemsManager
{
    public class SystemsManager : MonoBehaviour
    {
        private CustomSystem _currentSystem;

        [SerializeField] private CustomSystem[] combinedSystems;

        [SerializeField] private CustomSystem defaultSystem;

        private void Start()
        {
            _currentSystem = defaultSystem;
        }

        private void Update()
        {
            foreach (CustomSystem system in combinedSystems)
            {
                if (system.input.IsInput && system.priority < _currentSystem.priority)
                {
                    _currentSystem = system;
                }
            }

            _currentSystem.system.Action();
        }

        private void TrackCallSystem(AbstractInput inputSystem)
        {
            CustomSystem call = combinedSystems.FirstOrDefault(x => x.input == inputSystem);

            if (call == null) return;
            if (call.priority < _currentSystem.priority) return;

            _currentSystem = call;
        }

        // ReSharper disable once UnusedMember.Global
        public void TurnOffCurrentSystem()
        {
            if (_currentSystem != null && _currentSystem == defaultSystem) return;

            _currentSystem = defaultSystem;
        }
    }
}