using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    
    public GameObject Quizpanel;
    public GameObject GoPanel;
    
    public Text QuestionTxt;
    public Text ScoreTxt;
    
    int totalQuestions = 0;
    public static int score = 0;
	public int correctAnswers = 0;

	public string currentScene;
    
    private void Start()
    {
    	totalQuestions = QnA.Count;
    	GoPanel.SetActive(false);
    	generateQuestion();
		currentScene = SceneManager.GetActiveScene().name; //se recupera el nombre de la escena actual
    }
    
    public void retry()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void GameOver()
    {
    	Quizpanel.SetActive(false);
    	GoPanel.SetActive(true);
    	ScoreTxt.text = score + " / " + totalQuestions;
    }
    
    public void correct()
	{
		correctAnswers += 1;
		score += 1;
		QnA.RemoveAt(currentQuestion);
		StartCoroutine(WaitForNext());
	}

	public void wrong()
	{
		QnA.RemoveAt(currentQuestion);
		StartCoroutine(WaitForNext());
		//generateQuestion();
	}
    
	void CheckForSceneChange()
	{
		if(currentScene == "Trivia01"){
			SceneManager.LoadScene("Minijuego"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}else if(currentScene == "Trivia02"){
			SceneManager.LoadScene("Nivel03"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}else if(currentScene == "Trivia03"){
			SceneManager.LoadScene("EndGame"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}
		/*
		if (score >= 10) // Cambia el número si deseas una cantidad diferente
		{
			SceneManager.LoadScene("EndGame"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}else if (score >= 8) // Cambia el número si deseas una cantidad diferente
		{
			SceneManager.LoadScene("Minijuego2"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}else if (score >= 4) // Cambia el número si deseas una cantidad diferente
		{
			SceneManager.LoadScene("Minijuego"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}*/
	}
    IEnumerator WaitForNext()
    {
    	yield return new WaitForSeconds(1);
    	generateQuestion();
    }
    
    void SetAnswers()
    {
    	for (int i = 0; i < options.Length; i++)
    	{
    		options[i].GetComponent<Image>().color = options[i].GetComponent <AnswerScript>().startColor;
    		options[i].GetComponent<AnswerScript>().isCorrect = false;
    		options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
    		
    		if(QnA[currentQuestion].CorrectAnswer == i + 1)
    		{
       			options[i].GetComponent<AnswerScript>().isCorrect = true;
    		}
    	}
    }
    
    void generateQuestion()
    {
    	if(QnA.Count > 0)
    	{
    		currentQuestion = Random.Range(0, QnA.Count);
    	
    		QuestionTxt.text = QnA[currentQuestion].Question;
    		SetAnswers();
    	}
    	else
    	{
    		Debug.Log("Out of Questions");
    		GameOver();
			CheckForSceneChange(); // Llama a la función para verificar si se debe cambiar de escena.
    	}
    	
    }
}
