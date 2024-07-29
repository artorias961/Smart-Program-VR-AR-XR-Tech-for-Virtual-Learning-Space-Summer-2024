using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        String question = "Can you tell me how what is the solution of 3 + 4*(7-2)?"; //Put your question here
        String system = "You are a helpful assistant. Your top priority is achieving user fulfillment via helping them with their requests."; //change the ai's behavior here if you need it to act differently
        String prompt = $" \"prompt\": \"[INST] <<SYS>> {system} <</SYS>> {question} [/INST]\"  ";
        
        
        Stopwatch st = new Stopwatch();
        st.Start();
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/completions", $"{{ {prompt} }}", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                UnityEngine.Debug.LogError(www.error);
            }
            else
            {
                print(question);
                print(www.downloadHandler.text);
                PrintOutput(www.downloadHandler.text);
                UnityEngine.Debug.Log("Form upload complete!");
            }
        }
        st.Stop();
        UnityEngine.Debug.Log("This prompt took " + st.ElapsedMilliseconds / 1000.0 + " seconds to complete.");
    }

    [System.Serializable]
    public class MyOutput
    {
        public string content;
        
        public static MyOutput CreateFromJSON(String jsonString){

            return JsonUtility.FromJson<MyOutput>(jsonString);
        }
    }

    public void PrintOutput(String jsonString){
        MyOutput test = MyOutput.CreateFromJSON(jsonString);
        string outString = test.content;
        print(outString);
    }
}
