/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
https://developer.oculus.com/licenses/oculussdk/

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

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
            //_initialCameraSpace = GameObject.FindGameObjectWithTag("Player").transform.position;

            currentHand = GetNearestHand();
            initialHandPos = currentHand.transform.position;
            Destroy(this.gameObject.GetComponent<Outline>());

            switch(_grabbable.Transform.gameObject.name) {
                case "1":
                    var outline2 = GameObject.Find("2").AddComponent<Outline>();

                    outline2.OutlineMode = Outline.Mode.OutlineAll;
                    outline2.OutlineColor = Color.yellow;
                    outline2.OutlineWidth = 5f;
                    break;
                case "2":
                    var outline3 = GameObject.Find("3").AddComponent<Outline>();

                    outline3.OutlineMode = Outline.Mode.OutlineAll;
                    outline3.OutlineColor = Color.yellow;
                    outline3.OutlineWidth = 5f;
                    break;
                case "3":
                    var outline4 = GameObject.Find("4").AddComponent<Outline>();

                    outline4.OutlineMode = Outline.Mode.OutlineAll;
                    outline4.OutlineColor = Color.yellow;
                    outline4.OutlineWidth = 5f;
                    break;
                case "4":
                    var outline5 = GameObject.Find("5").AddComponent<Outline>();

                    outline5.OutlineMode = Outline.Mode.OutlineAll;
                    outline5.OutlineColor = Color.yellow;
                    outline5.OutlineWidth = 5f;
                    break;
                case "5":
                    var outline6 = GameObject.Find("6").AddComponent<Outline>();

                    outline6.OutlineMode = Outline.Mode.OutlineAll;
                    outline6.OutlineColor = Color.yellow;
                    outline6.OutlineWidth = 5f;
                    break;
                case "6":
                    var outline7 = GameObject.Find("7").AddComponent<Outline>();

                    outline7.OutlineMode = Outline.Mode.OutlineAll;
                    outline7.OutlineColor = Color.yellow;
                    outline7.OutlineWidth = 5f;
                    break;
                default:
                    break;
            }
            // if (this.gameObject.name == "3") {
            //     _grabbable.Transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
            // }
        }

        public void UpdateTransform()
        {
            //Debug.Log("woohoo");
            var targetTransform = _grabbable.Transform;

            Vector3 worldOffsetFromGrab = initialHandPos - currentHand.transform.position;

            player.transform.position += worldOffsetFromGrab;
            currentHand.transform.position = initialHandPos;
        }

        public void EndTransform() {
            currentHand = null;
        }

        private GameObject GetNearestHand()
        {
            float distFromLHand = Vector3.Distance(lHand.transform.position, _grabbable.Transform.position);
            float distFromRHand = Vector3.Distance(rHand.transform.position, _grabbable.Transform.position);

            if (distFromLHand < distFromRHand)
            {
                return lHand;
            }
            else
            {
                return rHand;
            }
        }
    }
}
