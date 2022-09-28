//Cracking the code interview 
/**
 * You have a large text file containing words. Given any two words,
 * find the shortest distance (in terms of number of words) between
 * them in the file. If the operation will be repeated many times
 * for the same file (but different pairs of words), can you
 * optimize your solution?
 */

//Questions,TestConditions,Solution proposition

//Questions
//Does this file fits into memory? And can we load file into memory?
//Can those two words be identical?
//Are those words ordered?



//Test conditions
//string[] words={}; =>
//string[] words={'cat'}=>
//string[] words={'cat','dog'} ('cat','dog')=>0
//string[] words={'cat','building','dog'} ('cat','dog')=>1
//!!!!!!!!!!!!!!Can we have mutliple words in the text!!!!!!!!!!!!! => this changes everything

//Solutions
//1.brute-force solution=>iterate =>2n
//2.brute-force solution with optimalization=>iterate =>n

//3.If ordered we can go with binary search =>O(log(n))
//4.If unordered or ordered and max efficient => dictionary<word,position> => O(1)

//[4,6,10]
//[7,8,20]


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var wordAndPosition = new Dictionary<string, List<int>>();
wordAndPosition.Add("cat", new List<int>() { 0, 5, 6 });
wordAndPosition.Add("dog", new List<int>() { 3, 9, 11 });
new WordDistance(wordAndPosition).Distance("cat", "dog");

class WordDistance
{

    class WordPosition
    {
        public WordPosition(string word, int position)
        {
            this.Word = word;
            this.Position = position;
        }
        public string Word;
        public int Position;
    }

    readonly Dictionary<string, List<int>> wordAndPosition = new Dictionary<string, List<int>>();

    public WordDistance(Dictionary<string, List<int>> wordAndPosition)
    {
        this.wordAndPosition = wordAndPosition;
    }


    public int Distance(string wordA, string wordB)
    {
        List<int> positionA = wordAndPosition[wordA];
        List<int> positionB = wordAndPosition[wordB];


        List<WordPosition> orderedWords = new List<WordPosition>();
        int wordAIndex = 0, wordBIndex = 0;
        while (wordAIndex < positionA.Count && wordBIndex < positionB.Count)
        {
            if (wordAIndex < positionA.Count && positionA[wordAIndex] < positionB[wordBIndex])//0,3
            {
                orderedWords.Add(new WordPosition(wordA, positionA[wordAIndex]));
                wordAIndex++;
            }
            else if (wordBIndex < positionB.Count && positionB[wordBIndex] < positionA[wordAIndex])
            {
                orderedWords.Add(new WordPosition(wordB, positionB[wordBIndex]));
                wordBIndex++;
            }
        }

        while (wordAIndex < positionA.Count)
        {
            orderedWords.Add(new WordPosition(wordA, positionA[wordAIndex]));
            wordAIndex++;
        }

        while (wordBIndex < positionB.Count)
        {
            orderedWords.Add(new WordPosition(wordB, positionB[wordBIndex]));
            wordBIndex++;
        }

        var result = int.MaxValue;
        var currentElement = orderedWords[0];
        for (int i = 1; i < orderedWords.Count; i++)
        {
            if (orderedWords[i].Word != currentElement.Word)
            {
                
                var min=Math.Abs(orderedWords[i].Position - currentElement.Position);
                if (min < result)
                {
                    result= min;
                }
                currentElement.Word = orderedWords[i].Word;
            }
        }

        Console.WriteLine(result);
        return result;
    }
}

