initializeKnightMoves
	"ChessPlayer initialize"
	| index px py moveList |
	KnightMoves _ Array new: 64 withAll: #().
	0 to: 7 do:[:j|
		0 to: 7 do:[:i|
			index _ (j * 8) + i + 1.
			moveList _ #().
			#( (-2 -1) (-1 -2) (1 -2) (2 -1) (-2 1) (-1 2) (1 2) (2 1)) do:[:spec|
				px _ i + spec first.
				py _ j + spec last.
				((px between: 0 and: 7) and:[py between: 0 and: 7]) ifTrue:[
					moveList _ moveList copyWith: (py * 8) + px + 1]].
			KnightMoves at: index put: moveList
		].
	].