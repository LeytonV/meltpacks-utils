using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MeltUtils.Decals
{
	public class DecalManager : MonoBehaviour
	{
		public static DecalManager instance;
		public List<DecalItem> decals;
		// Start is called before the first frame update
		void Start()
		{
			instance = this;
		}

		public void AddQuad(Material mat, Vector3 pos, Vector3 normal, Vector3 size, float rotateAmount = 0)
		{
			DecalItem item = decals.FirstOrDefault(x => x.mat == mat);
			if (item != null)
			{
				item.AddQuad(pos, normal, size, rotateAmount);
			}
			else
			{
				DecalItem newItem = new DecalItem();
				//New Transform
				Transform t = new GameObject(mat.name).transform;
				t.parent = transform;
				t.localPosition = Vector3.zero;
				t.localRotation = Quaternion.identity;

				newItem.transform = t;
				newItem.mat = mat;
				newItem.filter = newItem.transform.gameObject.AddComponent<MeshFilter>();
				newItem.rend = newItem.transform.gameObject.AddComponent<MeshRenderer>();
				newItem.rend.allowOcclusionWhenDynamic = false;
				newItem.Setup();


				decals.Add(newItem);
			}
		}

		public void Clear()
		{
			foreach (DecalItem item in decals)
			{
				item.Setup();
			}
		}
	}

	[System.Serializable]
	public class DecalItem
	{
		public Transform transform;
		public Material mat;
		public MeshFilter filter;
		public MeshRenderer rend;
		public Mesh mesh;
		Vector3[] vertices;
		int[] triangles;
		Vector2[] UV;
		Vector3[] normals;
		public int quadIndex;

		public void Setup()
		{
			quadIndex = 0;
			mesh = new Mesh();
			filter.mesh = mesh;
			rend.material = mat;
			vertices = new Vector3[0];
			triangles = new int[0];
			UV = new Vector2[0];
			normals = new Vector3[0];
		}

		public void AddQuad(Vector3 pos, Vector3 normal, Vector3 size, float rotateAmount = 0)
		{
			Quaternion rotation = Quaternion.LookRotation(normal.normalized);
			rotation = rotation * Quaternion.AngleAxis(rotateAmount, Vector3.forward);
			Vector3[] newVertices = new Vector3[]
			{
			pos + (rotation * new Vector3(-size.x / 2, -size.y / 2)), //Bottom Left 0
            pos + (rotation * new Vector3(-size.x / 2, size.y / 2)), //Top Left 1
            pos + (rotation * new Vector3(size.x / 2, size.y / 2)), //Top Right 2
            pos + (rotation * new Vector3(size.x / 2, -size.y / 2)) //Bottom Right 3
			};

			vertices = vertices.Concat(newVertices).ToArray();

			int[] newTriangles = new int[]
			{
			quadIndex + 0, quadIndex + 3, quadIndex + 2,
			quadIndex + 2, quadIndex + 1,quadIndex + 0
			};

			triangles = triangles.Concat(newTriangles).ToArray();
			quadIndex += 4;

			Vector2[] newUV = new Vector2[]
			{
			Vector2.zero, //Bottom Left
            new Vector2(0, 1), //Top Left
            Vector2.one, //Top Right
            new Vector2(1, 0)
			};
			UV = UV.Concat(newUV).ToArray();

			Vector3[] newNormals = new Vector3[]
			{
			normal,
			normal,
			normal,
			normal
			};
			normals = normals.Concat(newNormals).ToArray();

			UpdateMesh();
		}

		void UpdateMesh()
		{
			mesh.Clear();
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = UV;
			mesh.normals = normals;
		}
	}
}