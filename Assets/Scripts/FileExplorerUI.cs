using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileExplorerUI : MonoBehaviour
{

    //Variables for listing the directory contents    
    //A string that holds the directory path  
    public Transform scrollView;

    public GameObject listItem;

    public string directoryPath;
    //A List of strings that holds the file names with their respective extensions  
    private List<string> fileNames;

    private List<string> correctFiles = new List<string>();
    //A string that stores the full file path  
    private string fullFilePath;

    private string outputMessage;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(Application.streamingAssetsPath);
        //Append the '@' verbatim to the directory path string  
        this.directoryPath = @"" + Application.streamingAssetsPath; //this.directoryPath

        try
        {
            //Get the path of all files inside the directory and save them on a List  
            this.fileNames = new List<string>(Directory.GetFiles(this.directoryPath));

            if (fileNames.Count == 0)
            {
                Debug.Log(":(");
            }

            // Only allows movies with the fileendings: .mp4, .mov, .wmv.
            foreach (string file in fileNames)
            {
                if (file.EndsWith(".mp4") || file.EndsWith(".mov") || file.EndsWith(".wmv"))
                {
                    correctFiles.Add(file);
                }
            }

            foreach (string file in correctFiles)
            {
                GameObject g = Instantiate(listItem, scrollView);
                g.GetComponent<MovieListItem>().Initiate(Path.GetFileName(file));
            }

            

        }
        //Catch any of the following exceptions and store the error message at the outputMessage string  
        catch (System.UnauthorizedAccessException UAEx)
        {
            this.outputMessage = "ERROR: " + UAEx.Message;
        }
        catch (System.IO.PathTooLongException PathEx)
        {
            this.outputMessage = "ERROR: " + PathEx.Message;
        }
        catch (System.IO.DirectoryNotFoundException DirNfEx)
        {
            this.outputMessage = "ERROR: " + DirNfEx.Message;
        }
        catch (System.ArgumentException aEX)
        {
            this.outputMessage = "ERROR: " + aEX.Message;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
