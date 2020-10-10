using System;
using UniMob;
using UnityEngine;

namespace Sample
{
    public class WeaverTest
    {
        public int Source
        {
            get { return 1; }
            set { Debug.Log(value); }
        }

        [Atom]
        public int Weaved
        {
            get { return 1; }
            set { Debug.Log(value); }
        }

        private ComputedAtom<int> __Manual;

        public int Manual
        {
            get
            {
                if (__Manual == null)
                {
                    __Manual = CodeGenAtom.Create("Sample.WeaverTest::Manual", () => Manual);
                }

                if (!__Manual.DirectEvaluate())
                {
                    return __Manual.Value;
                }

                return 1;
            }
            set
            {
                if (__Manual == null || __Manual.CompareAndInvalidate(value))
                {
                    Debug.Log(value);
                }
            }
        }
    }
}