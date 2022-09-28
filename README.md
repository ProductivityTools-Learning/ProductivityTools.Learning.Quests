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

Repository is used to store different coding quests

<!--more-->

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
