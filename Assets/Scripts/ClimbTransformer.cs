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
        private Pose _previousGrabPose;
        private Vector3 _initialCameraSpace;
        private GameObject initialParent;
        private GameObject lHand;
        private GameObject rHand;


        public void Initialize(IGrabbable grabbable)
        {
            _grabbable = grabbable;
            lHand = GameObject.FindGameObjectWithTag("LHandAnchor");
            rHand = GameObject.FindGameObjectWithTag("RHandAnchor");
            initialParent = lHand.transform.parent.gameObject;
        }

        public void BeginTransform()
        {
            Pose grabPoint = _grabbable.GrabPoints[0];
            _previousGrabPose = grabPoint;
            _initialCameraSpace = GameObject.FindGameObjectWithTag("Player").transform.position;
            lHand.transform.SetParent(null);
            rHand.transform.SetParent(null);


        }

        public void UpdateTransform()
        {
            Debug.Log("woohoo");
            Pose grabPoint = _grabbable.GrabPoints[0];
            var targetTransform = _grabbable.Transform;

            Vector3 worldOffsetFromGrab = targetTransform.position - _previousGrabPose.position;
            //Vector3 offsetInGrabSpace = Quaternion.Inverse(_previousGrabPose.rotation) * worldOffsetFromGrab;
            //Quaternion rotationInGrabSpace = Quaternion.Inverse(_previousGrabPose.rotation) * targetTransform.rotation;

            GameObject.FindGameObjectWithTag("Player").transform.position = _initialCameraSpace + worldOffsetFromGrab;
            //targetTransform.rotation = grabPoint.rotation * rotationInGrabSpace;

            _previousGrabPose = grabPoint;
        }

        public void EndTransform() {
            lHand.transform.SetParent(initialParent.transform);
            rHand.transform.SetParent(initialParent.transform);
        }
    }
}
