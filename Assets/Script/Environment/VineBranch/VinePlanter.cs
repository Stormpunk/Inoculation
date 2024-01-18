using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class VinePlanter : MonoBehaviour
{
    public GameObject[] leafPrefabs;

    public float leafAmount = 0.06f;

    public Material vineTopMat, vineBottomMat;

    public float branchThickness = 0.1f;
    public float branchWidth = 0.5f;

    public float angleNormal = 0f;

    List<VineTree> trees = new List<VineTree>();
    [SerializeField]
    private GameObject vineStartPos;

    // Start is called before the first frame update
    void Start()
    {
        trees = new List<VineTree>();
    }

    private void Redraw() {
        for (int i = 0; i < trees.Count; i++)
        {
            trees[i].Redraw();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Redraw();
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                VineTree tree = new VineTree(origin: hit.point, normal: hit.normal, planter: this);
                trees.Add(tree);
                tree.Grow();
            }
        }
        if(vineStartPos.GetComponent<SpreadSpawner>().hasSpawned == false)
        {
            StartPosAimDown();
            vineStartPos.GetComponent<SpreadSpawner>().hasSpawned = true;
        }
    }

    private void OnDrawGizmos() {
        for (int i = 0; i < trees.Count; i++) {
            trees[i].DrawGizmos();
        }
    }

    public void StartPosAimDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(vineStartPos.transform.position, vineStartPos.transform.TransformDirection(Vector3.down), out hit))
        {
            VineTree newTree = new VineTree(origin: hit.point, normal: hit.normal, planter: this);
            trees.Add(newTree);
            newTree.Grow();
        }
    }
}
