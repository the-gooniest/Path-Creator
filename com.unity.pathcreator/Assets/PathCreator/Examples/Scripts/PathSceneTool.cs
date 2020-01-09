using UnityEngine;

namespace PathCreation.Examples
{
    [ExecuteInEditMode]
    public abstract class PathSceneTool : MonoBehaviour
    {
        public event System.Action onDestroyed;
        public PathCreator pathCreator;
        public bool autoUpdate = true;

        private bool _updateCallbackIsSet = false;

        protected VertexPath path {
            get {
                return pathCreator.path;
            }
        }

        public void TriggerUpdate() {
            PathUpdated();
        }

        protected virtual void OnValidate()
        {
            if (!_updateCallbackIsSet && pathCreator != null)
            {
                pathCreator.pathUpdated += PathUpdated;
                _updateCallbackIsSet = true;
            }
        }

        protected virtual void OnDestroy() {
            if (onDestroyed != null) {
                onDestroyed();
            }
        }

        protected abstract void PathUpdated();
    }
}
