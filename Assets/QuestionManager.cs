using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.CompilerServices;

public class QuestionManager : MonoBehaviour
{
    private Canvas CanvasObject;
    public TextMeshProUGUI questionTexts;
    public TextMeshProUGUI answerTexts;
    public TextMeshProUGUI Controls;

    private string[] questions = {
        "Meneekö kuvaus pilalle jos liikun?",
        "Saanko hengittää normaalisti? Loppuuko happi?",
        "Pitääkö silmät olla kiinni?",
        "Jäänkö huoneeseen ihan yksin? Kuuleeko kukaan?",
        "Entä jos tulee paniikki? Miten pääsen pois?",
        "Sulkeutuuko laite putken päistä, kun kuvaus alkaa? Liikkuuko laite?",
        "Tuleeko pimeää?",
        "Sattuuko kuvaus?",
        "Miltä tehosteaine tuntuu? Sattuuko se? Onko se vaarallista?",
        "Onko magneettikuvaus vaarallista tai haitallista? Onko magneetissa säteilyä?",
        "Kuinka kova meteli on? Entä jos säikähdän ääntä?",
        "Mitä jos onkin jokin metalli unohtunut?"
    };

    private string[] answers = {
        "Jos liikut, kuvia saatetaan joutua ottamaan uudelleen ja lisää, joten on tärkeää pysyä paikallaan, että kuvaus ei venyisi kovin pitkäksi",
        "Saat hengittää. Laite puhaltaa ilmaa putken läpi, minkä vuoksi hengittäminen on ihan helppoa koko ajan.",
        "Voit pitää silmiä kiinni tai auki, miten itse haluat. Niiden räpyttely ei haittaa.",
        "Vanhempi voi halutessasi olla sinun kanssasi huoneessa, mutta hänen kanssaan et voi keskustella. Kun painat hälytyspalloa, niin hoitajat huoneen ulkopuolella kuulevat sen.",
        "Kun painat hälytyspalloa, hoitaja tulee nopeasti ja auttaa. Pääset kyllä aivan varmasti tarvittaessa pois.",
        "Laite ei liiku eikä muutu mitenkään erilaiseksi, kuin miltä se nyt näyttää.",
        "Mikään ei muutu huoneessa erilaiseksi, kuin miltä tässä nyt näyttää.",
        "Kuvaus ei tunnu miltään eikä satu.",
        "Tehosteaine voi tuntua hiukan viileältä käsivarressasi, mutta se ei satu eikä ole vaarallista.",
        "Magneettikuvaus on turvallista eikä siinä ole säteilyä.",
        "Laitteen ääni on poraavaa ja naputtavaa, kuin joku tekisi remonttia viereisessä huoneessa. Sen vuoksi sinulla on korvatulpat ja kuulosuojaimet. Nämä vaimentavat äänen kyllä eikä se ole sil- loin liian kova. Joskus on ihan normaalia säpsähtää aluksi ääntä, mutta se ei haittaa, kunhan pysyt vaan paikoillasi.",
        "Kaikki metallinen on tarkistettu huolellisesti ennen kuvaushuoneeseen tuloa. Jos kuitenkin huomaat vielä vaikkapa vaatteissasi olevan metallin, voit painaa hälytyskelloa, jolloin hoitaja tulee tarkistamaan asian. Sen sijaan esimerkiksi ham- masraudat eivät haittaa mitään.",
    };
    private string[] controls = {
        "Takaisin kysymyksiin",
        "Lopeta"
    };
    private bool showingAnswers = false;


    void Start()
    {
        // Populate question placeholders with questions
        for (int i = 0; i < questions.Length; i++)
        {
            questionTexts.text += questions[i];
            questionTexts.text += "\n";
        }
        Debug.Log(questionTexts.text);
    }

    public void DisplayAnswer(int index)
    {
        // Display answer corresponding to the clicked question
        if (index >= 0 && index < answers.Length)
        {
            if (showingAnswers == true){
                if (index == 10)
                {
                    OnBackArrowClicked();
                }
                else if (index == 11)
                {
                    OnDoneButtonClicked();
                    Debug.Log("Exit");
                }
            }

            else
            {
                // Show answer
                answerTexts.text = answers[index];

                Controls.text += "Takaisin kysymyksiin";
                Controls.text += "\n";
                Controls.text += "Lopeta";

                // Hide or disable question
                questionTexts.text="";

                // Update state
                showingAnswers = true;

            }
        }
    }
    public void OnBackArrowClicked()
    {
        // If showing answers, go back to showing questions
        if (showingAnswers)
        {
            answerTexts.text = "";
            Controls.text = "";
            // Show questions
            for (int i = 0; i < questions.Length; i++)
            {
                questionTexts.text += questions[i];
                questionTexts.text += "\n";
            }

            // Update state
            showingAnswers = false;
        }
    }

    public void OnDoneButtonClicked()
    {
        // Hide canvas
        CanvasObject = GetComponent<Canvas> ();
        CanvasObject.enabled = !CanvasObject.enabled;
    }
}
