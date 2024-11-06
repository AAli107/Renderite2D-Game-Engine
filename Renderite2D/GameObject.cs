using System.Collections.Generic;

namespace Renderite2D_Project.Renderite2D
{
    public class GameObject
    {
        public bool IsEnabled { get { return isEnabled; } set { isEnabled = value; } }

        public Transform2D transform = new();
        
        bool isEnabled = true;
        readonly List<Component> components = new();

        public void Update()
        {
            if (!IsEnabled) return;

            for (int i = 0; i < components.Count; i++)
                if (components[i] != null && components[i].IsEnabled)
                    components[i]?.Update();
        }

        public Component[] GetAllComponents()
        {
            return components.ToArray();
        }

        public Component GetComponent<T>() where T : Component
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is T)
                    return components[i];
            }
            return null;
        }

        public Component[] GetComponents<T>() where T : Component
        {
            List<Component> foundComponents = new();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is T)
                    foundComponents.Add(components[i]);
            }
            return foundComponents.ToArray();
        }
    }
}
