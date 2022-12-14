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


public class WordTreeNode
{
    public WordTreeNode(string word)
    {
        this.Word = word;
        this.Nodes = new List<WordTreeNode>();
    }
    public string Word { get; set; }
    public List<WordTreeNode> Nodes { get; set; }
}
public class WordLadder
{
    //contains American dictionary
    private readonly string[] Dictionary;

    //Contains dictionary of n-letters word (in our example 4)
    private readonly List<string> DictionaryOfNLettersWord = new List<string>();

    //array which contains dictionaries in the format, part of the word + letters which create word together with the part
    //for example dictionary in n-1 position will contain 3 first letter of the word and in the
    //dictionary value, rest of the word
    private Dictionary<string, List<string>>[] WordParts;

    private WordTreeNode SourceNode;
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


    private void LoadTree(string startWord)
    {
        this.SourceNode = new WordTreeNode(startWord);
        HashSet<string> visited = new HashSet<string>();
        Queue<WordTreeNode> toProcess = new Queue<WordTreeNode>();
        toProcess.Enqueue(this.SourceNode);

        while (toProcess.Count > 0)
        {
            WordTreeNode node = toProcess.Dequeue();
            if (!visited.Contains(node.Word))
            {
                visited.Add(node.Word);
                for (int i = 0; i < node.Word.Length; i++)
                {
                    var wordPart = node.Word.Substring(0, i) + node.Word.Substring(i + 1, node.Word.Length - 1 - i);
                    if (this.WordParts[i].ContainsKey(wordPart))
                    {
                        this.WordParts[i][wordPart].ForEach(x =>
                        {
                            var fullWord = node.Word.Substring(0, i) + x + node.Word.Substring(i + 1, node.Word.Length - 1 - i);
                            if (!visited.Contains(fullWord))
                            {
                                var newNode = new WordTreeNode(fullWord);
                                toProcess.Enqueue(newNode);
                                node.Nodes.Add(newNode);
                            }
                        });
                    }
                }
            }
        }
    }

    private Stack<WordTreeNode> DFS(string endWord)
    {
        Stack<WordTreeNode> path = new Stack<WordTreeNode>();
        var start = this.SourceNode;
        if (start.Word == endWord)
        {
            return path;
        }

        path.Push(start);
        DFSStep(endWord, start, path);
        return path; 
    }

    private bool DFSStep(string endWord,WordTreeNode currentNode, Stack<WordTreeNode> path)
    {
        foreach (WordTreeNode node in currentNode.Nodes)
        {
            path.Push(node);
            if (node.Word==endWord)
            {
                return true;
            }
            else
            {
                var result = DFSStep(endWord, node, path);
                if (result==false)
                {
                    path.Pop();
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void PrintResult(Stack<WordTreeNode> steps)
    {
        foreach (var item in steps)
        {
            Console.WriteLine($"{item.Word} ");
        }
    }

    public void GetPath(string startWord, string endWord)
    {
        int wordLength = startWord.Length;
        FilterDictionary(wordLength);
        LoadDictoinaryOfNLettersWord(wordLength);
        LoadTree(startWord);
        var result=DFS(endWord);
        PrintResult(result);
        Console.ReadLine();
    }
}