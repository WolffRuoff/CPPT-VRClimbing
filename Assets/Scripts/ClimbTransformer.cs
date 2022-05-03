/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
https://developer.oculus.com/licenses/oculussdk/

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using Oculus.Interaction.Grab;
using UnityEngine;

namespace Oculus.Interaction
{
    /// <summary>
    /// A Transformer that moves the oculus camera in a 1-1 fashion inverted with the GrabPoint.
    /// Updates transform the target in such a way as to maintain the target's
    /// local positional and rotational offsets from the GrabPoint.
    /// </summary>
    public class ClimbTransformer : MonoBehaviour, ITransformer
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
        }

        public void UpdateTransform()
        {
            Vector3 worldOffsetFromGrab = initialHandPos - currentHand.transform.position;

            player.transform.position += worldOffsetFromGrab;
            currentHand.transform.position = initialHandPos;
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
                    Debug.Log("Unselecting " + hand.name);
                    hand.GetComponent<IInteractor>().Unselect();
                }
            }
        }
    }
}
