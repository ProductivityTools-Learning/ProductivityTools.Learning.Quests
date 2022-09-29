// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] Dictionary = new string[9];
Dictionary[0] = "DAMP";
Dictionary[1] = "LAMP";
Dictionary[2] = "LIMP";
Dictionary[3] = "LIME";
Dictionary[4] = "LIKE";
Dictionary[5] = "LALA";
Dictionary[6] = "WUJCZYK";
Dictionary[7] = "RAMP";
Dictionary[8] = "DAMD";

var wordLadder = new WordLadder(Dictionary);
wordLadder.GetPath("DAMP", "LIKE");


public class WordGraphNode
{
    public WordGraphNode(string word)
    {
        this.Word = word;
        this.Nodes = new List<WordGraphNode>();
    }
    public string Word { get; set; }
    public List<WordGraphNode> Nodes { get; set; }
}
public class WordLadder
{

    private class RemovedLetter
    {
        public string Letter { get; set; }
    }

    private readonly string[] Dictionary;
    private readonly List<string> DictionaryOfNLettersWord = new List<string>();

    private Dictionary<string, List<string>>[] WordParts;

    private WordGraphNode SourceNode;
    public WordLadder(string[] dictionary)
    {
        this.Dictionary = dictionary;
    }

    private void FilterDictionary(int wordLength)
    {
        foreach (var item in Dictionary)
        {
            if (item.Length == wordLength)
            {
                DictionaryOfNLettersWord.Add(item);
            }
        }
    }

    private void LoadDictoinaryOfNLettersWord(int length)
    {

        this.WordParts = new Dictionary<string, List<string>>[length];

        Action<int, string, string> addToWordParts = (index, word, letter) =>
          {
              if (this.WordParts[index].ContainsKey(word))
              {
                  this.WordParts[index][word].Add(letter);
              }
              else
              {
                  this.WordParts[index][word] = new List<string>() { letter };
              }
          };

        for (int i = 0; i < length; i++)
        {
            WordParts[i] = new Dictionary<string, List<string>>();
            foreach (var item in this.DictionaryOfNLettersWord)
            {
                var wordPart = item.Substring(0, i) + item.Substring(i + 1, length - 1 - i);
                var letter = item.Substring(i, 1);
                addToWordParts(i, wordPart, letter);
            }
        }
    }


    private void LoadGraph(string startWord)
    {
        this.SourceNode = new WordGraphNode(startWord);
        HashSet<string> visited = new HashSet<string>();
        Queue<WordGraphNode> toProcess = new Queue<WordGraphNode>();
        toProcess.Enqueue(this.SourceNode);

        while (toProcess.Count > 0)
        {
            WordGraphNode node = toProcess.Dequeue();
            if (!visited.Contains(node.Word))
            {
                visited.Add(node.Word);
                for (int i = 0; i < startWord.Length; i++)
                {
                    var wordPart = startWord.Substring(0, i) + startWord.Substring(i + 1, startWord.Length - 1 - i);
                    if (this.WordParts[i].ContainsKey(wordPart))
                    {
                        this.WordParts[i][wordPart].ForEach(x =>
                        {
                            var fullWord = startWord.Substring(0, i) + x + startWord.Substring(i + 1, startWord.Length - 1 - i);
                            if (!visited.Contains(fullWord))
                            {
                                var newNode = new WordGraphNode(fullWord);
                                toProcess.Enqueue(newNode);
                                node.Nodes.Add(newNode);
                            }
                        });
                    }
                }
            }
        }

    }

    public void GetPath(string startWord, string endWord)
    {
        int wordLength = startWord.Length;
        FilterDictionary(wordLength);
        LoadDictoinaryOfNLettersWord(wordLength);
        LoadGraph(startWord);

        throw new NotImplementedException();
    }
}