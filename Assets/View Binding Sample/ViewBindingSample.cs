using System.Collections;
using CodeWriter.ViewBinding;
using UnityEngine;

namespace View_Binding_Sample
{
    public class ViewBindingSample : MonoBehaviour
    {
        [SerializeField]
        private ViewVariableBool soundEnabled = default;

        [SerializeField]
        private ViewVariableBool musicEnabled = default;

        [SerializeField]
        private ViewVariableFloat volume = default;

        [SerializeField]
        private ViewVariableString str = default;

        private IEnumerator Start()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(0.2f);
                soundEnabled.Value = true;
                musicEnabled.Value = false;

                yield return new WaitForSeconds(0.2f);
                soundEnabled.Value = false;
                musicEnabled.Value = true;

                yield return new WaitForSeconds(0.2f);
                str.Value = "Hello!";

                yield return new WaitForSeconds(0.2f);
                str.Value = "WORLD";
            }
        }
    }
}