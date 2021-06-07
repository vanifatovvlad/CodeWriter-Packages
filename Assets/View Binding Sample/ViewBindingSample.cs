using System;
using System.Collections;
using CodeWriter.ViewBinding;
using UniMob;
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

        [Atom] private bool SoundEnabled { get; set; }
        [Atom] private bool MusicEnabled { get; set; }
        [Atom] private string Str { get; set; }
        [Atom] private float Volume { get; set; }

        private IEnumerator Start()
        {
            soundEnabled.SetSource(Atom.Computed(() => SoundEnabled));
            musicEnabled.SetSource(Atom.Computed(() => MusicEnabled));
            str.SetSource(Atom.Computed(() => Str));
            volume.SetSource(Atom.Computed(() => Volume));

            while (enabled)
            {
                yield return new WaitForSeconds(0.02f);
                SoundEnabled = true;
                MusicEnabled = false;

                yield return new WaitForSeconds(0.02f);
                SoundEnabled = false;
                MusicEnabled = true;

                Volume = (Time.time % 1) * 100;

                yield return new WaitForSeconds(0.02f);
                Str = "Hello!";

                yield return new WaitForSeconds(0.02f);
                Str = "WORLD";
            }
        }
    }
}