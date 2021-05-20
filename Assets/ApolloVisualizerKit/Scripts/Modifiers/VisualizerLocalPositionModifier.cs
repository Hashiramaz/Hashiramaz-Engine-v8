using UnityEngine;
using System.Collections;
namespace Apollo
{
    [AddComponentMenu("Apollo/Modifiers/Local Position Modifier")]
    public class VisualizerLocalPositionModifier : VisualizerObjectBase
    {


        public enum yesno { Yes, No };
        //public yesno UsesRigidbody;
        //Drop down menu
        public yesno UseLerp;
        //multiplier for the range value
        [Range(0.0f, 1)]
        public float LerpSpeed;
        public bool UseBasePosition;
        private Vector3 BasePosition;
        //public Rigidbody myRB;

        public Vector3 V3modifier;

        public void Awake()
        {
            BasePosition = transform.localPosition;
        }

        void ChangePosition()
        {

            EvaluateRange();

            Vector3 mod = V3modifier * modifier;
            if (UseBasePosition)
            {
                mod += BasePosition;
            }
            if (mod.x == 0)
            {
                mod.x = transform.localPosition.x;
            }
            if (mod.y == 0)
            {
                mod.y = transform.localPosition.y;
            }
            if (mod.z == 0)
            {
                mod.z = transform.localPosition.z;
            }

            switch (UseLerp)
            {
                case yesno.No:
                    transform.localPosition = mod;

                    break;
                case yesno.Yes:
                    transform.localPosition = Vector3.Lerp(transform.localPosition, mod, LerpSpeed);
                    break;
            }

            /*
            if(UsesRigidbody==yesno.Yes){
                switch(axis_to_transform){
                case Axis.X:
                    myRB.velocity = new Vector3(modifier*multiplier,transform.localPosition.y,transform.localPosition.z);

                    break;
                case Axis.Y:
                    myRB.velocity = new Vector3(transform.localPosition.x,modifier*multiplier,transform.localPosition.z);

                    break;
                case Axis.Z:
                    myRB.velocity = new Vector3(transform.localPosition.x,transform.localPosition.y,modifier*multiplier);

                    break;
                }
            }else{
                switch(axis_to_transform){
                case Axis.X:
                    transform.localPosition = new Vector3(modifier*multiplier,transform.localPosition.y,transform.localPosition.z);

                    break;
                case Axis.Y:
                    transform.localPosition = new Vector3(transform.localPosition.x,modifier*multiplier,transform.localPosition.z);

                    break;
                case Axis.Z:
                    transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,modifier*multiplier);

                    break;
                }
            }*/


        }

        // Update is called once per frame
        void Update()
        {
            ChangePosition();
        }
    }
}