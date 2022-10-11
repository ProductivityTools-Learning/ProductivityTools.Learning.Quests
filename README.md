<!--Category:C#,SQL--> 
 <p align="right">
    <a href="http://productivitytools.tech/productivitytools-createsqlserverdatabase/"><img src="Images/Header/ProductivityTools_green_40px_2.png" /><a> 
    <a href="https://github.com/ProductivityTools-Learning/ProductivityTools.Example.GCP.SecretManager"><img src="Images/Header/Github_border_40px.png" /></a>
</p>
<p align="center">
    <a href="http://http://productivitytools.tech/">
        <img src="Images/Header/LogoTitle_green_500px.png" />
    </a>
</p>


# Quests


Repository is used to store different coding quest.
[Draw.io file](https://app.diagrams.net/#G1z-c3mN3V7xB3Kej71jyUp6bZdj1GPvhg)

<!--more-->

## Cracking the code interview

### Array and strings(83,181)

<img src="./Images/Icons/yes.png" width="12"/> **Implement an algorithm to detrime if a string has all unique characters. What if you cannot use additional data structures** 

- If string lenght is more than letters in alphabet => false
- If we can use additional structure then iteration and hashset with seen letters - Time complexity: O(n) iteration+ n*O(1) Hashset=O(2n)
- We can improve the hashset by creating array with all the characters in advance and null them when found in string
- We can also sort the array and check if we have two letters the same next to each other O(n log(n))


<img src="./Images/Icons/yes.png" width="12"/> **Implement a function which reverses a null terminated string**

- cat => tac
- Create an additional array and rewrite string
- while loop, with two pointers
- for loop with one going from start and second string.lenght-1-firstIterator

 <img src="./Images/Icons/no.png" width="12"/> **Given two strings write a method to decide if one is a permutation of the other**
 - what is permutation? = all words creatd from given set of letters is permutation
 - check the lenght
 - sort and compare the elements
 - check if in the second word we have all leters as in the first one
 - check if strings have the same character count <img src="./Images/Icons/repeat.png" width="12"/>
 - if this case sensitive <img src="./Images/Icons/repeat.png" width="12"/>
 - if we trim the sapces <img src="./Images/Icons/repeat.png" width="12"/>

<img src="./Images/Icons/yes.png" width="12"/>  **Write a method to replace all spaces in string with '%20' you may assume that the string has sufficient space at the end of the string. Please do it in place**

- If we won't do it in place it is simple we create the second array and copy 
- Other way we need to start from the end

<img src="./Images/Icons/no.png" width="12"/> **Implement a method to perform basic string compression using the counts of repated characters. aabcccccaa would become a2b1c5a3. If the 'compressed string would not become smaller than the original string your method should return the original string**

- the compression makes only sense if we have more doubled letters than single ones, we could check it in advance
- simple while
- use string buffer <img src="./Images/Icons/repeat.png" width="12"/>
- as string concatention is expensive and we do not want to use string buffer we need to count size of the target string <img src="./Images/Icons/repeat.png" width="12"/>

<img src="./Images/Icons/no.png" width="12"/> **Given an image represented by NxN matrix write where each pixel in the image is 4 butes write a method to rotate the image by 90 degress. Can you do this in place?**

- int[,] a = new int[4,4]
```
R,C=>R,C
0,0=>0,3
0,1=>1,3
0,2=>2,3
0,3=>3,3
```

```
R,C=>R,C
0,0=>0,3
1,0=>0,2
2,0=>0,1
3,0=>0,0
```

```C#
int dimension=a.GetLength(0);//3
for(int row=0;row<a.GetLength(0);row++)
{
    for(int column=0;column<a.GetLegth(1);column++>)
    {
      b[column,dimension-row]=a[row,column]
    }
}
```

- multiple layers not only first row <img src="./Images/Icons/repeat.png" width="12"/>
- not sure if I want to analyze it

<img src="./Images/Icons/yes.png" width="12"/>  **Write an althoritm such that if an element in an MxN matrix is 0 its entire row and column are set to 0**
- The matrix is done, so we need to look at the matrix and change it, everytime when we see the 0 we should set whole row and column to 0
- The difficult part is when we will setup first time the row and column then we are loosing some information (we do not know if we covered some 0)
- We could iterate table and save in two arrays rows and columns to zero


<img src="./Images/Icons/no.png" width="12"/> **Assume you have a method isSubstring which checks if one word is a substring of another Given two strings S1 and S2 Write code to check if S2 is a rotation of S1 using only one call to is substring**

- What is a rotation, we can move a part of the sentence to the end like=>ikel or =>keli
- We can sort the string and call the method, but this could give us false positives  <img src="./Images/Icons/repeat.png" width="12"/>
- better is join twice the word so kelikeli for sure has like inside

### LinkedLists (86,192)

<img src="./Images/Icons/no.png" width="12"/> **Write code to remove duplicates from an unsorted linked list. How would you solve this problem if a temporary buffer is not allowed?**
- create a hashset with all met values
- sort list (with quick sort version)
- <img src="./Images/Icons/repeat.png" width="12"/> Two pointers, wone which points on the current element and second one which will look ofr duplicates

<img src="./Images/Icons/no.png" width="12"/> **Implement an alghorithm to find the kth to last element of the singly linked list.**
- <img src="./Images/Icons/repeat.png" width="12"/> If the list link size is known we can just iterate to the lenght - k element
- two pointers one which will be k elements behind the first one
-  we need two pointers one which points to the current element and second which validates other nodes
- <img src="./Images/Icons/repeat.png" width="12"/> Recursive algorithm recurses throught he list. When it hits the end the method basses back a counter set to 0. EAch parent call adds 1 to this counter. Problem here is how to return the node, we can print it or pass by the reference

<img src="./Images/Icons/yes.png" width="12"/>  **Implement an alghoritm to delete a node in the middle onf the singly linked list given only acces to that node. Example Input: the node C from the linked list a->b->c->d->e**

**Result: nothing is returned but the new linked list looks like a->b->d->e**
- we need to rewrite all values from the next node to the current one and remove the pointer to the next one

<img src="./Images/Icons/yes.png" width="12"/>  **Write a code to partition a linked list around a value x such that all nodes less than  x come before all nodes greated than equal to x**
- Create two lists and merge as the last step

**You have two number represented by a linked list where ach node contains a single digit. The digits are sorted in reverse order such taht 1's digit is at the head of the list. Write a function that addes the two numbers and returns the sum of as a linked list** CODE

**Example:
Input (7->1->6)+(5->9->2) that is 617 +295 
Output (2->1->9) That is 912**

**Follow-up suppose the digits are stored in forward order**

**Given a circular linked list, implement an alghorithm which returns the node at the beginning of the loop**
- We can save reference to each node in hashset to validate if we had already one item
- We can go with two pinters, one which points current element and second which id going to the end of the list validating if they will meet again
- To detect the loop we can use fast runner slow runner, they should meet eventualy
- Not doing it too complex.

<img src="./Images/Icons/no.png" width="12"/> **Implement a function to check if a linked list is a palindrome**
- Palidrome so the numbers are the same forward and backwards - 12321
- Is the list one way linked?
- <img src="./Images/Icons/repeat.png" width="12"/> If we know the size we can reverse half of the list and compare
- We can push all the items on the stack and take them , but then we will need to know what is the size

### Stack and Queues (89,211)
<img src="./Images/Icons/no.png" width="12"/> **Describe how you could use a single array to implement three stacks**
- Should I have 3 operatios PushA, PushB, PushC?
- This is one dimension array of simple type?
- Cam I assume size of the stacks?
- Do the stack have the same size?
- use modulo3 to chose the place
- split the array into 3 parts
- do we know what numbers we will put there? Maybe we could add like 100, 200, 300 to each number
- stack has the O(1) complexity shoudl array have the same? - not sure if this is possible
- <img src="./Images/Icons/repeat.png" width="12"/>  We can mark when the stack starts wich additional pointer, and we could have multiple sections for each stack 

<img src="./Images/Icons/no.png" width="12"/> **How would you design a stack which in addition to push and pop also has a function min which returns the minimum element? Push, pop and min should all operate in O(1) time**
- the easiest way it will be to iterate through stack and find the new number
- but as it need sto peperate in O(1) time we need to store the value during the poping and pushing
- difficult part is poping element as we need to remember where the last min was
- we can store it in the dictionary or additional stack with the minimum values or we can store object on the stack with two properties
- <img src="./Images/Icons/repeat.png" width="12"/> I would go with the separate stack as the minimum doesn't change often

<img src="./Images/Icons/yes.png" width="12"/> **Imagine a (literal) stack of plates. If stack gets too high it might topple. Therfore in real life we would likely start a new stack when the previous stack exceeds some threshold. Implement a data structure SetOfStacks that mimics new stack once the precious one exceeds capacity. SetOfStacks.push and SetOcStacks.pop() should behave identically to a single stack (thit is pop() should return the same values as it would if there were just a single stack). Follow up Implement a function PopAt(int index) which performs a pop operation on specific sub-stack**
- simple implemantation


<img src="./Images/Icons/yes.png" width="12"/>**In the classic problem of Towers of Hanoi you have 3 towers and N disks of different sizes  which can slide onto any tower. The puzzle starts with disks sorted in ascending order of size from top to bottom (i.e. each disk sits on top of an even larger one) You have collowin constraints**

**- only wone disk can be moved at a time**

**- a disk is lid of the top of one tower onto the next tower**

**- a disk can only be placed on top of the larger disk**
- not interesting

<img src="./Images/Icons/yes.png" width="12"/> **Implement a MyQuene class which implements a quene using two stacks**
- if we have time when we are enquening and time when dequening we can move all the content from one stack to another when needed



<img src="./Images/Icons/no.png" width="12"/> **Write a program to sort a stack in ascending order (with biggest items on top). You may use at most one additional stack to hold items, but you may not copy the elements into other data structure (such as array) the stack supports the followign operations: push, pop, peek, and is empty** 

- We can sort S1 by inserting elements into correct place
- add first element ot the S1
- check if the second element should be below or above, if below move the elements on the S2

<img src="./Images/Icons/yes.png" width="12"/> **An animal shelter holds only dogs and cats, and operates on a strictly first in first out basis. People must adopt either the "oldest" of all animals at the shelter or they can select whether they would prefer a dog or a cat (and will receive the oldest animal of that type). They cannot select which specific animal they would like. Create the data structures to maintain ths system and implement operations such as enquene, dequeneAny, dequeneDog and dequeneCat. You may use the bild in Linked List data structure**
- simple algorithm

### Tree and Graphs (95,)

<img src="./Images/Icons/yes.png" width="12"/> **Implement a function to check if a binary tree is balanced. For the purppose of this question a balanced tree is defined to be a tree such that the heights of the two subtrees of any node never differ by more than one**
- code written

<img src="./Images/Icons/yes.png" width="12"/> **Given a directed graph design an alghorithm to find out wheter there is a route between two nodes**
- DFS, BFS

**Given a sorted (increasing order) array with unique integer elements, write an althoritm to create a binary search tree with minimal height**

**Given a binary tree, design an algorithm which creates a linked list of all the nodes at each depth (if you have a tree with dept D you will have D linked lists)**

**Implement a function to check if a binary tree is binary search tree**
- <img src="./Images/Icons/no.png" width="12"/>  again copy to the array and check if its ordered
- <img src="./Images/Icons/no.png" width="12"/>  below is wrong BST, so if we want to traverse and compare we also need to pass the max value

![](Images/2022-10-11-22-35-12.png)


**Write an algorithm to find the next node (in-order sucessor) of a given node in a binary search tree. You may assume that each node ha  a link to its parent**

- To be discussed during interview

**Design an althoritm and write code to find the first common ancestor of two nodes in a binary tree. Avoid storing additional nodes in a data structure. Not this is not necessarily a binary search tree**

- common ancestor - is a node which is a first parent for both of the nodes
- <img src="./Images/Icons/yes.png" width="12"/>  We need to traverse to the tree, saving the path to each node. Then go through two paths and check where the paths diverge
- <img src="./Images/Icons/no.png" width="12"/> do the nodes have liks to parents?

**You have two very large binary trees: T1 with milion of nodes and T2 with hundrets of nodes. Create algorithm to decide fi T2 is subtre of T1. A Tree T2 is subtree of T1 if there exists a node n in T1 such that the subtreee of n is identical to T2. That is if you cut off the tree at node n the two trees would be identical**

- <img src="./Images/Icons/yes.png" width="12"/>  I can look for the root of the subtree and then start to compare node by node
- <img src="./Images/Icons/yes.png" width="12"/> If I can change the way how three is created I would calculate hashcode for each subtree somethink like blockchain
- <img src="./Images/Icons/no.png" width="12"/> for smal tree we can change it into string and call substring


<img src="./Images/Icons/no.png" width="12"/> **You are given a binary tree in which each node contains a value. Design an alghoritm to print all paths which sum to given value. The path does not need to start or end ethe root or a leaf**

Simplify—What if the path had to start at the root, but could end anywhere? In this case, we would have a much easier problem. We could start from the root and branch left and right, computing the sum thus far on each path. When we find the sum, we print the current path. Note that we don't stop traversing that path just because we found the sum. Why? Because the path could continue on to a +1 node and a -1 node (or any other sequence of nodes where the additional values sum to 0), and the full path would still sum to sum. 
Now, what if the path can start anywhere? In that case, we can make a small modifica-tion. On every node, we look "up" to see if we've found the sum. That is, rather than asking "Does this node start a path with the sum?;' we ask, "Does this node complete a path with the sum?" When we recurse through each node n, we pass the function the full path from root to n. This function then adds the nodes along the path in reverse order from n to root. When the sum of each subpath equals sum, then we print this path. 


- Binary tree - is a tree data structure in which each node has at most two children, which are referred to as the left child and the right child. 
- Binary search tree - also called an ordered or sorted binary tree, is a rooted binary tree data structure with the key of each internal node being greater than all the keys in the respective node's left subtree and less than the ones in its right subtre

![](Images/2022-10-11-21-40-32.png)
![](Images/2022-10-11-21-40-07.png)
## WordDistance

```
//Cracking the code interview 
/**
 * You have a large text file containing words. Given any two words,
 * find the shortest distance (in terms of number of words) between
 * them in the file. If the operation will be repeated many times
 * for the same file (but different pairs of words), can you
 * optimize your solution?
 */
```

- Brute force solution is to iterate through the words and look for the shortest distance it is ok solution for invoking one
- For invoking several times: create a dictionary from words to have positions to the locations of the words. For this dictionary also two solutions
  -  Use additional structure in which we will again order words and then calculate distance between two neightbors - easier to debug, more time and space complex
  - Calcualte distance on the fly - optimum solution


## Word ladder

### Quest
[source](https://leetcode.com/problems/word-ladder/)

  ```
  Given a dictionary containing a list of words, a starting word, and an ending word, return the minimum number of steps to transform the starting word into the ending word.

A step involves changing one letter at a time to a valid word that is present in the dictionary.

Return null if it is impossible to transform the starting word into the ending word using the dictionary.

Example:

transformWord(‘DAMP’, ‘LIKE’)
Output: DAMP->LAMP->LIMP->LIME->LIKE
```
### Solution

- Filter all words in the dictionary to filter words with given amount of letters

If we are looking for 4 letters word Dictionary[6] will be removed
```C#
Dictionary[0] = "DAMP";
Dictionary[1] = "LAMP";
Dictionary[2] = "LIMP";
Dictionary[3] = "LIME";
Dictionary[4] = "LIKE";
Dictionary[5] = "LALA";
Dictionary[6] = "WUJCZYK";
Dictionary[7] = "RAMP";
Dictionary[8] = "DAMD";
```

- Create array of dictionaries where 
  - key -  will be with n-1 (in our example 3) part of the words
  - value - will contain letters which when inserted into particular place will create a word

Example:
Id of the dictionary informs us about the place where we should insert letter.
Below example show us **AMP**. on the 0 index we have array of 3 letters which creates different word from our dictionary

![](Images/2022-09-30-07-53-23.png)

On the 0 index we also have other words. Below example of **IMP**

![](Images/2022-09-30-07-56-29.png)

On the second position of 4 letter word we have the same situation

![](Images/2022-09-30-07-57-53.png)


- build a tree
  - take the first word which was given as argument and take all combinations of substrings DAMP (AMP,DMP,AMP) - it will be looked in  in previously defined dictionaries
![](Images/2022-09-30-08-04-15.png)

- use DFS or BFS to find path
- print path


## BFS
It shows how to do BFS with the undirected graph. Objects could have connections beteen each over A has reference to B, and B has reference to A. Connections are not weighted.

BFS cannot be used to find the shortest path. Dijkstra's algorithm adapts BFS to let you find single-source shortest paths.

To print the path from one node to the node which we had been looking for, we need to save reference to parent.

BFS we are usually doing with the Queue and the while. We are adding all nodes on given level to the queue and while queue is not empty we are processing elements

![](Images/2022-10-01-07-29-02.png)


## DFS

- **Important** difficult part is returning value and poping in right place

```c#
Visited.Add(node);
Path.Push(node);
if (node.Name == lookUpValue)
{
    return node;
}
else
{
    foreach (var childNode in node.Nodes)
    {
        if (Visited.Contains(childNode) == false)
        {
            var result=Search(childNode, lookUpValue);
            if (result == null)
            {
                Path.Pop();
            }
        }
    }
    return null;
}
```

### BFS vs DFS
||BFS|DFS|
|--|---|---|
|Working object|Node contains node|Node contains node|
|Working function|NodeQueue|Recursion|
|Path object|ChildParentDictionary|Stack

## Dijkstra

- We need to have nodes and the edges. Edge needs to contain From and To Node reference
- Weights cannot be negative

![](Images/2022-10-03-21-36-27.png)

## MST Prim

- Do it also with the array instead of names
- Performed for the same graph as Djkstra

### Comparing Prim’s and Dijkstra’s Algorithms
In the computation aspect, Prim’s and Dijkstra’s algorithms have three main differences:

- Dijkstra’s algorithm finds the shortest path, but Prim’s algorithm finds the MST
- Dijkstra’s algorithm can work on both directed and undirected graphs, but Prim’s algorithm only works on undirected graphs
- Prim’s algorithm can handle negative edge weights, but Dijkstra’s algorithm may fail to accurately compute distances if at least one negative edge weight exists

In practice, Dijkstra’s algorithm is used when we want to save time and fuel traveling from one point to another. Prim’s algorithm, on the other hand, is used when we want to minimize material costs in constructing roads that connect multiple points to each other.

|Dijkstra|Prim|Kruskal|
|---|---|---|
|EdgePriorityQueue|EdgePriorityQuene|EdgePriorityQuene|
|NodesVisitedHashset|NodesVistedHashset|QuickUnion<Node>|
|DistanceToDictionary|EdgeMSTList|MST| 