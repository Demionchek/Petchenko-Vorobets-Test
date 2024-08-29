using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:Component {

    private static T instance;
    
    public static T Instance { 
        get { 
            if (instance == null) {
                instance = FindAnyObjectByType<T>();
                if (instance == null) {
                    GameObject go = new GameObject("Controller");
                    instance = go.AddComponent<T>();
                }
            }
            return instance; 
        } 
    }

    private void Awake() {
        if (instance == null) {
            instance = this as T;
        } else {
            if (instance != this) Destroy(gameObject);
        }
    }
}