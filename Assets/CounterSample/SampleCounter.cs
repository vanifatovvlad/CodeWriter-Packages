using UniMob;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class SampleCounter : MonoBehaviour
    {
        public Text counterText = default;
        public Button incrementButton = default;

        [Atom] private int Counter { get; set; }

        private void Start()
        {
            incrementButton.onClick.AddListener(() => Counter += 1);

            Atom.Reaction(() => counterText.text = "Tap count: " + Counter);
        }
    }
}