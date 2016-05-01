using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Extensions {

    public static System.Random localRandom = new System.Random();

    public static void SetLayer(this Transform root, int layer)
    {
        Stack <Transform> children = new Stack<Transform> ();
        children.Push (root);
        while (children.Count > 0) {
            Transform currentTransform = children.Pop ();
            currentTransform.gameObject.layer = layer;
            foreach (Transform child in currentTransform)
                children.Push (child);
        }
    }

    public static void AddIfNotNull<T>(this List<T> list, T thing){
        if(thing != null){
            list.Add(thing);
        }
    }

    public static bool AtEndOfAnimation(this Animator animator){
        if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1 && !animator.IsInTransition (0)) {
            return false;
        }return true;
    }

    public static void TurnLayerOn(this Camera c, string layerName){
        c.cullingMask |= 1 << LayerMask.NameToLayer(layerName);
    }

    public static void TurnLayerOff(this Camera c, string layerName){
        c.cullingMask &=  ~(1 << LayerMask.NameToLayer(layerName));
    }

	public static bool Between(this int tested, int lowEnd, int highEnd){
		return tested >= lowEnd && tested <= highEnd;
	} 

	public static bool Between(this float tested, float lowEnd, float highEnd){
		return tested >= lowEnd && tested < highEnd;
	} 

    public static Vector3 OnlyXZ(this Vector3 v3){
        return new Vector3(v3.x,0,v3.z);
    }

    public static T GetRandomElement<T>(this IEnumerable<T> list, System.Random random) {
        if (list.Count() == 0)
            return default(T);
        return list.ElementAt(random.Next(list.Count()));
    }

	public static List<Transform> GatherChildren(this GameObject g){
		List<Transform> children = new List<Transform> ();
		foreach (Transform t in g.transform) {
			if (t != g.transform) {
				children.Add (t);
			}
		}
		children.ForEach (x => {
			x.parent = null;
		});
		return children;
	}

    public static string ToStringAll<T>(this T[] array) {
        if (array.Length == 0){
            return "empty";
        }
        string s = "";
        foreach(T n in array){
            s += n.ToString() + " | ";
        }
        return s;
    }

    public static List<T> Sort<T>(this List<T> list)  { 
        list.Sort();
        return list;
    }

    public static int IndexConstrain(this int index, int max) { 
        if(index > max){
            return 0;
        }
        else if (index < 0) {
            return max;
        }
        else {
            return index;
        }
    }

    public static T GetRandomElement<T>(this IEnumerable<T> list) {
        if (list.Count() == 0)
            return default(T);
        return list.ElementAt(localRandom.Next(list.Count()));
    }

    public static T GetRandomElementExcluding<T>(this IEnumerable<T> list, IEnumerable<T> excludes) {
        if (list.Count() == 0)
            return default(T);

        List<T> filtered = (from n in list
                       where !(excludes.Contains(n))
                        select n).ToList<T>();

        if (filtered.Count == 0) {
            return default(T);
        }else if (filtered.Count == 1) {
            return filtered[0];
        } return filtered.GetRandomElement<T>();
    }

    public static T GetRandomElement<T>(this T[] array) {
        if (array.Length == 0)
            return default(T);
        return array.ElementAt(localRandom.Next(array.Length));
    }
   	
	public static T Chomp<T>(this List<T> list,T defaultTo) {

		if(list.Count == 0){
			return defaultTo;
		}

		T b = list[0];
		list.Remove(b);
		return b;
	}

	public static T Snatch<T>(this List<T> list, int index){
		T b = list[index];
		list.Remove(b);
		return b;
	}

	public static T Chomp<T>(this List<T> list) {
		T b = list[0];
		list.Remove(b);
		return b;
	}

	public static T ChompLast<T>(this List<T> list, T defaultTo) {

		if(list.Count == 0){
			return defaultTo;
		}

		T b = list[list.Count-1];
		list.RemoveAt(list.Count-1);
		return b;
	}

	public static T ChompUntil<T>(this List<T> list, T defaultTo, int size) {

		if(list.Count == 0){
			return defaultTo;
		}

		if(list.Count <=size){
			return list.Chomp();
		}

		if(list.Count == 0){
			return defaultTo;
		}

		while(list.Count > size+1){
			list.Chomp();
		}

		return list.Chomp();
	}

	public static T ChompRandom<T>(this List<T> list) {
		int rand = localRandom.Next(list.Count());
		T b = list[rand];
		list.RemoveAt(rand);
		return b;
	}


    public static List<T> Shuffle<T>(this List<T> list, System.Random rng) {
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

    public static Vector3 Round(this Vector3 vect) {
        return new Vector3(Mathf.RoundToInt(vect.x), Mathf.RoundToInt(vect.y), Mathf.RoundToInt(vect.z));
    }

	public static Vector3 CeilXToInt(this Vector3 vect){
		return new Vector3(Mathf.CeilToInt(vect.x),vect.y,vect.z);
	}
	
	public static Vector3 CeilZToInt(this Vector3 vect){
		return new Vector3(vect.x,vect.y,Mathf.CeilToInt(vect.z));
	}

	public static Vector3 RoundXToInt(this Vector3 vect){
		return new Vector3(Mathf.RoundToInt(vect.x),vect.y,vect.z);
	}
	
	public static Vector3 RoundZToInt(this Vector3 vect){
		return new Vector3(vect.x,vect.y,Mathf.RoundToInt(vect.z));
	}

    public static Vector3 CentreOfVerts(this MeshFilter filter) {
        Vector3 avg = new Vector3();
        foreach (Vector3 v in filter.mesh.vertices) {
            avg += v;
        }
        return avg / filter.mesh.vertexCount;
    }

    public static bool IsEven(this int i) {
        return (i % 2) == 0;
    }

    public static float MinComp(this Vector3 vect) {
        float toReturn = vect[0];
        for (int i = 1; i < 3; i++) {
            if (vect[i] < toReturn) {
                toReturn = vect[i];
            }
        }
        return toReturn;
    }

    public static T Duplicate<T>(this T prefab, Vector3 position, Quaternion rotation) where T : Object {
        return (T)Object.Instantiate(prefab, position, rotation);
    }

    public static T Duplicate<T>(this T prefab, Vector3 position) where T : Object {
        return (T)Object.Instantiate(prefab, position, Quaternion.identity);
    }

    public static T Duplicate<T>(this T prefab) where T : Object {
        return prefab.Duplicate(Vector3.zero);
    }

    public static T Duplicate<T>(this T prefab, Transform transform) where T : Object {
        return prefab.Duplicate(transform.position, transform.rotation);
    }
}


