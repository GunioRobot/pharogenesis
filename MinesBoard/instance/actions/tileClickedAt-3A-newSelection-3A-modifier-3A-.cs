tileClickedAt: location newSelection: isNewSelection modifier: mod
	| tile |
	"self halt."
	gameOver ifTrue: [^ false].
	tile _ self tileAt: location.

	isNewSelection ifFalse: [
		mod ifTrue: [
				tile mineFlag: ((tile mineFlag) not).
				tile mineFlag ifTrue: [owner minesDisplay value: (owner minesDisplay value - 1)]
						ifFalse: [owner minesDisplay value: (owner minesDisplay value + 1)].
				^ true.].

		gameStart ifFalse: [ 
			self setMines: location.
			gameStart _ true. 
			owner timeDisplay start.].
		^ self stepOnTile: location.
		]
	ifTrue:[ self clearMines: location.].