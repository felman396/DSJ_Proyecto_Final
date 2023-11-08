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
    public int score;
	public int correctAnswers = 0;
    
    private void Start()
    {
    	totalQuestions = QnA.Count;
    	GoPanel.SetActive(false);
    	generateQuestion();
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
		if (correctAnswers >= 4) // Cambia el número si deseas una cantidad diferente
		{
			SceneManager.LoadScene("Nivel02"); // Reemplaza "NuevaEscena" con el nombre de la escena a la que deseas cambiar.
		}
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
