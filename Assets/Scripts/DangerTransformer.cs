using Oculus.Interaction.Grab;
using UnityEngine;

// This class handles the special case transformations for the "danger knobs", where as a user
// places their hand on a danger knob, it recognizes that and destroys the grabbable object i.e. the knob.
namespace Oculus.Interaction
{
    public class DangerTransformer : MonoBehaviour, ITransformer
    {
        private IGrabbable _grabbable;
        private GameObject lHand;
        private GameObject rHand;
        private GameObject currentHand;
        private Vector3 initialHandPos;
        private GameObject player;

        public void Initialize(IGrabbable grabbable)
        {
            _grabbable = grabbable;
            lHand = GameObject.FindGameObjectWithTag("LHandAnchor");
            rHand = GameObject.FindGameObjectWithTag("RHandAnchor");
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void BeginTransform()
        {
            SetGrabbingHand();
            initialHandPos = currentHand.transform.position;

            _grabbable.Transform.gameObject.SetActive(false);
        }

        public void UpdateTransform()
        {

        }

        public void EndTransform() {
        }

        private void SetGrabbingHand()
        {
            foreach (GameObject hand in GameObject.FindGameObjectsWithTag("GrabInteractor"))
            {
                if (hand.GetComponent<IHandGrabInteractor>().HandGrabApi.transform.GetPose().Equals(_grabbable.GrabPoints[0])) {
                    if (hand.name.Contains("Left"))
                    {
                        currentHand = lHand;
                    }
                    else
                    {
                        currentHand = rHand;
                    }
                }
                else
                {
                    hand.GetComponent<IInteractor>().Unselect();
                }
            }
        }
    }
}
