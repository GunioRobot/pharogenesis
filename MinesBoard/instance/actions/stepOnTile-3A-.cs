stepOnTile: location

	| mines tile |
	tile _ self tileAt: location.
	tile mineFlag ifFalse:[
		tile isMine ifTrue: [tile color: Color gray darker darker. self blowUp. ^false.]
			ifFalse:[
				mines _ self findMines: location.
				tile switchState: true.
				tileCount _ tileCount + 1.
				mines = 0 ifTrue: 
					[self selectTilesAdjacentTo: location]].
		tileCount = ((columns*rows) - self preferredMines) ifTrue:[ gameOver _ true. flashCount _ 2. 	owner timeDisplay stop.].
		^ true.] 
		ifTrue: [^ false.]

