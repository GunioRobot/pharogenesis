initializeRookMoves
	"ChessPlayer initialize"
	| index moveList1 moveList2 moveList3 moveList4 px py |
	RookMoves _ Array new: 64 withAll: #().
	0 to: 7 do:[:j|
		0 to: 7 do:[:i|
			index _ (j * 8) + i + 1.
			moveList1 _ moveList2 _ moveList3 _ moveList4 _ #().
			1 to: 7 do:[:k|
				px _ i + k. py _ j.
				((px between: 0 and: 7) and:[py between: 0 and: 7]) ifTrue:[
					moveList1 _ moveList1 copyWith: (py * 8) + px + 1].
				px _ i. py _ j + k.
				((px between: 0 and: 7) and:[py between: 0 and: 7]) ifTrue:[
					moveList2 _ moveList2 copyWith: (py * 8) + px + 1].
				px _ i - k. py _ j.
				((px between: 0 and: 7) and:[py between: 0 and: 7]) ifTrue:[
					moveList3 _ moveList3 copyWith: (py * 8) + px + 1].
				px _ i. py _ j - k.
				((px between: 0 and: 7) and:[py between: 0 and: 7]) ifTrue:[
					moveList4 _ moveList4 copyWith: (py * 8) + px + 1].
			].
			RookMoves at: index put: {moveList1. moveList2. moveList3. moveList4}.
		].
	].