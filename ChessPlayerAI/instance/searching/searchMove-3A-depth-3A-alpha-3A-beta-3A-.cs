searchMove: theBoard depth: depth alpha: initialAlpha beta: initialBeta 
	"Modified version to return the move rather than the score"

	| move score alpha bestScore moveList newBoard beta goodMove |
	self assert: [initialAlpha < initialBeta].
	ply < 10 ifTrue: [(variations at: ply + 1) at: 1 put: 0].
	ply := 0.
	alpha := initialAlpha.
	beta := initialBeta.
	bestScore := AlphaBetaMinVal.

	"Generate new moves"
	moveList := generator findPossibleMovesFor: theBoard activePlayer.
	moveList ifNil: [^nil].
	moveList isEmpty 
		ifTrue: 
			[generator recycleMoveList: moveList.
			^nil].

	"Sort move list according to history heuristics"
	moveList sortUsing: historyTable.

	"And search"
	[(move := moveList next) isNil] whileFalse: 
			[newBoard := (boardList at: ply + 1) copyBoard: theBoard.
			newBoard nextMove: move.
			"Search recursively"
			ply := ply + 1.
			score := 0 - (self 
								search: newBoard
								depth: depth - 1
								alpha: 0 - beta
								beta: 0 - alpha).
			stopThinking 
				ifTrue: 
					[generator recycleMoveList: moveList.
					^move].
			ply := ply - 1.
			score = AlphaBetaIllegal 
				ifFalse: 
					[score > bestScore 
						ifTrue: 
							[ply < 10 ifTrue: [self copyVariation: move].
							goodMove := move copy.
							goodMove value: score.
							bestScore := score].
					"See if we can cut off the search"
					score > alpha 
						ifTrue: 
							[alpha := score.
							score >= beta 
								ifTrue: 
									[transTable 
										storeBoard: theBoard
										value: score
										type: (ValueBoundary bitOr: (ply bitAnd: 1))
										depth: depth
										stamp: stamp.
									historyTable addMove: move.
									alphaBetaCuts := alphaBetaCuts + 1.
									generator recycleMoveList: moveList.
									^goodMove]]]].
	transTable 
		storeBoard: theBoard
		value: bestScore
		type: (ValueAccurate bitOr: (ply bitAnd: 1))
		depth: depth
		stamp: stamp.
	generator recycleMoveList: moveList.
	^goodMove