using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public int CurrentIndex;

    public List<int> Scores = new List<int>();
    public List<string> Titles;
    public List<string> TextsQuest1;
    public List<string> TextsQuest2;
    public List<string> TextsQuest3;
    public List<string> TextsQuest4;
    public List<string> TextsQuest5;
    public List<string> TextsQuest6;
    public List<string> TextsQuest7;
    public List<string> TextsQuest8;

    public Text TitleText;
    public List<Text> QuestionTexts;

    public Text YourStyleTitle;
    public Text YourStyleDesc;

    public GameObject Result;

    public void GoToLogin()
    {
        SceneManager.LoadScene("Main");
    }

    void ResetScores()
    {
        for (int i1 = 0; i1 < Scores.Count; i1++)
        {
            Scores[i1] = 0;
        }
    }

    public void ResetQuiz()
    {
        ResetScores();
        Result.SetActive(false);
        CurrentIndex = 0;
        UpdateQuest();
    }

    private void Start()
    {
        UpdateQuest();
    }
    List<string> GetQuestionByIndex(int index)
    {
        if (index == 0)
        {
            return TextsQuest1;
        }
        else if (index == 1)
        {
            return TextsQuest2;
        }
        else if (index == 2)
        {
            return TextsQuest3;
        }
        else if (index == 3)
        {
            return TextsQuest4;
        }
        else if (index == 4)
        {
            return TextsQuest5;
        }
        else if (index == 5)
        {
            return TextsQuest6;
        }
        else if (index == 6)
        {
            return TextsQuest7;
        }
        else if (index == 7)
        {
            return TextsQuest8;
        }
        else
        {
            return null;
        }

    }
    public void UpdateQuest()
    {
        if (CurrentIndex < Titles.Count)
        {
            TitleText.text = Titles[CurrentIndex];
            int i = 0;
            foreach (Text txt in QuestionTexts)
            {

                txt.text = GetQuestionByIndex(CurrentIndex)[i];
                i++;
            }
        }
        else
        {
            SetStyleByBestScoreIndex(GetBestScoreIndex());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetStyleByBestScoreIndex(GetBestScoreIndex());
        }
    }

    public void SetScoreByIndex(int index)
    {
        Scores[index] += 1;
        CurrentIndex++;
        UpdateQuest();
    }

    int GetBestScoreIndex()
    {
        int value = 0;
        int index = 0;
        for (int i = 0; i < Scores.Count; i++)
        {
            if (Scores[i] > value)
            {
                value = Scores[i];
                index = i;
            }
        }
        Debug.Log("O indice mais escolhido foi " + index);
        return index;
    }
    void SetStyleByBestScoreIndex(int index)
    {
        Result.SetActive(true);
        if (index == 0)
        {
            YourStyleTitle.text = "Clássico";
            YourStyleDesc.text = "Seu estilo é clássico! Este estilo inclui itens que todo mundo deveria ter no guarda-roupa. Investe em qualidade e peças que nunca saem de moda. É um estilo que transmite confiabilidade, adequado principalmente para a área profissional. Você certamente não costuma usar muito cores fortes, transparência ou decotes. \n Dica: Procure em alguns momentos inserir peças mais ousadas para dar uma equilibrada.";
            Debug.Log("Clássico (Maioria das Respostas: Letra A)");
        }
        else if (index == 1)
        {
            YourStyleTitle.text = "Elegante";
            YourStyleDesc.text = "Ual! Seu estilo é elegante! Você provavelmente se preocupa bastante com a sua aparência, não é? Prioriza roupas duráveis, materiais de qualidade refinada, mas, principalmente, está sempre de olho nas tendências e procura sempre estar na moda e alinhada à ocasião que vai. Por isso mesmo nunca está nem muito chique e nem muito simples, e sim na medida certa. O estilo elegante é utilizado por pessoas de opinião forte, seguras, sofisticadas, exigentes e muito respeitadas. \n Dica: Busque relaxar um pouco e mixar seu estilo com alguma peça mais despojada, assim você pode dar uma variada e ter mais conforto.";
            Debug.Log("Elegante(Maioria das Respostas: Letra B)");
        }
        else if (index == 2)
        {
            YourStyleTitle.text = "Moderno";
            YourStyleDesc.text = "Seu estilo é o moderno! Também conhecido como dramático urbano. Isso quer dizer que você é uma pessoa muito ligada ao meio urbano e isso se reflete nas suas roupas. Certamente você ama a cor preta e abusa do contraste: claro-escuro. Gosta de explorar referências geométricas, estampas gráficas e contemporâneas com peças que trazem volumes exagerados. Ou então você é mais do tipo que curte um visual propositadamente largado e rebelde, com referências no punk rock. As peças chave deste estilo são jeans destroyed, blusas e casacos volumosos e/ou com gola alta, jaqueta de couro, peças estruturadas e de design marcante, coturno, plataforma e outros sapatos pesados.";
            Debug.Log("Moderno (Maioria das Respostas: Letra C)");
        }
        else if (index == 3)
        {
            YourStyleTitle.text = "Esportivo ou Natural";
            YourStyleDesc.text = "Olha, o seu estilo é o casual/esportivo! Também conhecido como básico. Você certamente preza pela praticidade e põe seu conforto em primeiro lugar. E talvez até te falte um pouco de vaidade. Peças de qualidade fazem parte do seu guarda-roupa, mas sempre muito práticas e simples. Você transmite uma imagem leve, alegre e despretensiosa. Algumas peças chaves do seu estilo são o jeans, a malha, as mochilas, as rasteirinhas e sandálias anabella; jaqueta jeans e o tênis, claro. \n Dica: Dá para manter o conforto e a discrição com um pouco de cor.Aposte em alguns acessórios coloridos, assim você conseguirá dar uma variada nos looks, sem precisar ousar tanto.";
            Debug.Log("Esportivo ou Natural (Maioria das Respostas: Letra D)");
        }
        else if (index == 4)
        {
            YourStyleTitle.text = "Sexy";
            YourStyleDesc.text = "Ual! O seu estilo é ousadia e poder… Ops! Quis dizer é o SEXY! Esse certamente não é um estilo para qualquer pessoa, é preciso ter muita confiança. Você provavelmente é uma pessoa determinada, atraente, dominadora e se sente confortável com seu próprio corpo, por isso, busca peças que valorizam e evidenciam o seu físico. Possui uma personalidade corajosa, autêntica, confiante, sensual e carismática. Peças com decote, transparência, recortes e com um bom caimento não podem faltar no seu closet. Inclusive, o animal print é uma estampa que não sai de lá, não é? \n Dica: Esse é um estilo que merece atenção para manter o equilíbrio.Então, escolha o que vai ser o destaque da vez.Um decote mais cavado ou uma transparência podem harmonizar muito bem com uma calça mais larguinha. Vai usar uma lingerie, talvez uma jaqueta ou um blazer casem muito bem com ela. Se você é homem, um shortinho mais curto ou uma calça mais justa vai melhor com uma blusa mais folgadinha.";
            Debug.Log("Sexy (Maioria das Respostas: Letra E)");
        }
        else if (index == 5)
        {
            YourStyleTitle.text = "Romântico";
            YourStyleDesc.text = "Awm! O seu estilo é o romântico. *-* Você deve ter uma preferência por roupas e acessórios fofos e delicados, tons suaves e tecidos leves, não é? Suas roupas e acessórios transmitem a sua personalidade romântica, tímida, delicada, gentil e refinada. Provavelmente você é alguém que ama e suspira assistindo a filmes de comédia romântica ou lendo romances. Você também se atrai pela estética campestre, floral e bucólica? Uma foto em um piquenique ou em um campo de flores é tudoo! \n Dica: Busque dar uma quebrada quando o look estiver muito tom pastel, equilibrando com algumas cores mais sóbrias. Ou, também cai muito bem, incluir algo mais sexy.Se você é mulher, uma saia rodada, por exemplo, vai bem com um body lingerie.";
            Debug.Log("Romântico (Maioria das Respostas: Letra F)");
        }
        else if (index == 6)
        {
            YourStyleTitle.text = "Criativo";
            YourStyleDesc.text = "Seu estilo é criativo! Você busca utilizar a roupa como forma de expressão e isso é o máximo! Você usa a moda a seu favor e pode transitar por mais de um estilo. Não seguindo apenas as tendências, mas colocando sua personalidade em cada look e de acordo com o seu humor. Gosta de misturar peças, ousar e brincar com a moda. Possui uma personalidade inovadora, criativa, artística, divertida, exótica e confiante. \n Dica: É super divertido brincar e mixar estilos, mas às vezes você pode se sentir meio deslocado, caso ouse muito.Então, busque se informar sobre a ocasião que você vai e quais são as tendências do momento, assim, você com certeza vai poder usar sua criatividade mais estrategicamente.";
            Debug.Log("Criativo (Maioria das Respostas: Letra G)");
        }

    }
}
