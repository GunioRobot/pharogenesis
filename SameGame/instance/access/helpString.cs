helpString
	^ 'The object of SameGame is to maximize your score by removing tiles from the board.  Tiles are selected and removed by clicking on a tile that has at least one adjacent tile of the same color (where adjacent is defined as up, down, left, or right).

The first click selects a group of adjacent tiles, a second click in that group will remove it from the board, sliding tiles down and right to fill the space of the removed group.  If you wish to select a different group, simply click on it instead.

The score increases by "(selection - 2) squared", so you want to maximize the selection size as much as possible.  However, making small strategic selections may allow you to increase the size of a later selection.

If you are having a hard time finding a group, the "Hint" button will find one and select it for you (although it is likely not the best group to select!).

When there are no more groups available, the score display will flash with your final score.  Your final score is reduced by 1 for each tile remaining on the board.  If you manage to remove all tiles, your final score is increased by a bonus of 5 times the number of tiles on a full board.

Come on, you can beat that last score!  Click "New game"  ;-)

SameGame was originally written by Eiji Fukumoto for UNIX and X; this version is based upon the same game concept, but was rewritten from scratch.' translated