using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameZone : MonoBehaviour
{
    private int screenSizeWidth;
    private int screenSizeHeight;
    private Chunk[] chunks;
    private Action OnNextChunkAction;
    private Action OnWinScreenAction;
    private Chunk cnank;
    private List<Vector3> characterListPosition = new List<Vector3>();
    private int currentChunk;
    private Character character;

    public void Setup(Chunk[] chunks, Action OnWinScreenAction,Character character = null)
    {
        this.chunks = chunks;
        this.OnWinScreenAction = OnWinScreenAction;
        this.character = character;
    }
    void Start()
    {
        OnNextChunkAction += GoToNextChunk;
       
        float scale = (float)UnityEngine.Screen.width / UnityEngine.Screen.height;
        transform.localScale = new Vector3(scale,scale,scale);
    }
  
    private void FixedUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (IsThisLastChunk())
        {
            OnWinScreenAction?.Invoke();
        }
        else
        {
            if (currentChunk > 0)
            {
                if (transform.position != characterListPosition[currentChunk] )
                {
                    Vector3 pos = new Vector3(characterListPosition[currentChunk].x,-characterListPosition[currentChunk].y,transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 1);
                }  
            }
        }
    }
    private void GoToNextChunk()
    {
        character.StartPause();
        StartCoroutine(NextChunk());
        currentChunk += 1;
        character.StopPause();
    }

    private bool IsThisLastChunk()
    {
        if (characterListPosition.Count == currentChunk)
        {
            return true;
        }
        return false;
    }
    
    public void SpawnChunk()
    {
        float orthographicSize = Camera.main.orthographicSize * 2.0f;
          
        for (int i = 0; i < chunks.Length; i++)
        {
            Chunk chunk = Instantiate(chunks[i], transform);
            chunk.Setup(OnNextChunkAction);
            chunk.transform.position = new Vector3(0, orthographicSize * i, 0);
            characterListPosition.Add(chunk.transform.position);
        }
       
    }

    private IEnumerator NextChunk()
    {
        Score.Instance.PauseOn();
        Physics.autoSimulation = false;
        yield return new WaitForSeconds(3);
        Physics.autoSimulation = true;
        Score.Instance.PauseOff();
    }
}