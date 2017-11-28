# vanhackathon-7snake-game
Vanhackaton 27/11/2017, delivery at 28/11/2017
This problem is a typical search problem much like tic-tac-toe or chess. You must search through a (large) space for possible solutions

Ascent Software Challenge
http://www.ascentsoftware.eu/
Playing with 7-Snakes

# My Solution using stacks:
> My solution use stacks to maintain a list of snakes that aren't completed yet. 
> It starts with one snake at stack with its first node at a position (0,0) for example, after that its adjacents cells are enumerated, following defined rules. 
> Next valid nodes in this case would be (1,0)(0,1), a new snake is cloned from the previous one, for each valid node enumerated. 
> So, after the stack will have then Snake1=(0,0)(1,0) and Snake2=(0,0)(0,1). 
> After completing a snake with 7 nodes, it birth and is placed into a dictionary thas has a total value as its key and a list of snakes with same total value. 
> Once new snakes were being generating, a comparing is made into this dictionary to find the first 2 that has the same total amount.
> Ps: The stacks was used to avoid recursion, it kept the solution iterative and faste


This problem is a typical search problem much like tic-tac-toe or chess. You must search through a (large) space for possible solutions. The cleverness (in our view) is in the way you enumerate the search space.
Let’s start with some definitions:
Consider the Grid A below. A 7-Snake is a sequence of cells c1, c2, …,c7 in a grid such that each cell is adjacent to the one before it. 
More formally, for 1 ≤ i < 7, ci+1 is adjacent to ci. 
Two cells a and b are adjacent if b is to the top, bottom, left, or right of a. 
Given an arbitrary ordering of the cells in a 7-Snake, each cell ci, can only be adjacent to ci-1 or ci+1.  Note that this exclude cycles.
In Grid A below, the yellow and blue 7-Snakes are valid but the green one is not. This is because cell 7 is not to the top, bottom, left, or right of cell 6. ‘Diagonal’ adjacency is not allowed.

![GridA][grid_a]

# Problem Definition:
The problem is very simple to describe. Given a grid of integers such as Grid B below, find a pair (two) of 7-Snakes A and B that has the property that the sum of the integers in 7-Snake A is exactly the same as the sum of integers in 7-Snake B

![GridB][grid_b]

# Notes:
The two 7-Snakes must be distinct. They cannot share cells.
In general there may be more than one pair of 7-Snakes with the required property. Your program need only find one pair.
If no such pair exists the program should output ‘FAIL’. Otherwise it should output the first pair it finds that has the above property.
The solution depends on your ability to enumerate the set of all pairs of distinct 7-Snakes in the given grid.
In general, the input grid can be any (square) size. Grid B above is just an example of a 10 X 10 grid. The grid should be stored in CSV format on disk and loaded by your solution. This will allow us to test your solution on various test examples. The integers in each cell must range from 1 to 256. 

Solution:
![Solution][solution]


[solution]: /solution.png "Solucao"
[grid_a]: /grida.png "Solucao"
[grid_b]: /gridb.png "Solucao"


