quiesce: theBoard alpha: initialAlpha beta: initialBeta 
	"A variant of alpha-beta considering only captures and null moves to obtain a quiet position, e.g. one that is unlikely to change heavily in the very near future."

	| move score alpha entry bestScore moveList newBoard beta |
	self assert: [initialAlpha < initialBeta].
	ply < 10 ifTrue: [(variations at: ply + 1) at: 1 put: 0].
	nodesVisited := nodesVisited + 1.
	"See if there's already something in the transposition table."
	entry := transTable lookupBoard: theBoard.
	alpha := initialAlpha.
	beta := initialBeta.
	entry isNil 
		ifFalse: 
			[ttHits := ttHits + 1.
			(entry valueType bitAnd: 1) = (ply bitAnd: 1) 
				ifTrue: [beta := entry value max: initialBeta]
				ifFalse: [alpha := 0 - entry value max: initialAlpha].
			beta > initialBeta ifTrue: [^beta].
			alpha >= initialBeta ifTrue: [^alpha]].
	ply < 2 
		ifTrue: 
			["Always generate moves if ply < 2 so that we don't miss a move that
		would bring the king under attack (e.g., make an invalid move)."

			moveList := generator findQuiescenceMovesFor: theBoard activePlayer.
			moveList ifNil: [^0 - AlphaBetaIllegal]].

	"Evaluate the current position, assuming that we have a non-capturing move."
	bestScore := theBoard activePlayer evaluate.
	"TODO: What follows is clearly not the Right Thing to do. The score we just evaluated doesn't take into account that we may be under attack at this point. I've seen it happening various times that the static evaluation triggered a cut-off which was plain wrong in the position at hand.
	There seem to be three ways to deal with the problem. #1 is just deepen the search. If we go one ply deeper we will most likely find the problem (although that's not entirely certain). #2 is to improve the evaluator function and make it so that the current evaluator is only an estimate saying if it's 'likely' that a non-capturing move will do. The more sophisticated evaluator should then take into account which pieces are under attack. Unfortunately that could make the AI play very passive, e.g., avoiding situations where pieces are under attack even if these attacks are outweighed by other factors. #3 would be to insert a null move here to see *if* we are under attack or not (I've played with this) but for some reason the resulting search seemed to explode rapidly. I'm uncertain if that's due to the transposition table being too small (I don't *really* think so but it may be) or if I've just got something else wrong."
	bestScore > alpha 
		ifTrue: 
			[alpha := bestScore.
			bestScore >= beta 
				ifTrue: 
					[moveList ifNotNil: [generator recycleMoveList: moveList].
					^bestScore]].

	"Generate new moves"
	moveList ifNil: 
			[moveList := generator findQuiescenceMovesFor: theBoard activePlayer.
			moveList ifNil: [^0 - AlphaBetaIllegal]].
	moveList isEmpty 
		ifTrue: 
			[generator recycleMoveList: moveList.
			^bestScore].

	"Sort move list according to history heuristics"
	moveList sortUsing: historyTable.

	"And search"
	[(move := moveList next) isNil] whileFalse: 
			[newBoard := (boardList at: ply + 1) copyBoard: theBoard.
			newBoard nextMove: move.
			"Search recursively"
			ply := ply + 1.
			score := 0 - (self 
								quiesce: newBoard
								alpha: 0 - beta
								beta: 0 - alpha).
			stopThinking 
				ifTrue: 
					[generator recycleMoveList: moveList.
					^score].
			ply := ply - 1.
			score = AlphaBetaIllegal 
				ifFalse: 
					[score > bestScore 
						ifTrue: 
							[ply < 10 ifTrue: [self copyVariation: move].
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
										depth: 0
										stamp: stamp.
									historyTable addMove: move.
									alphaBetaCuts := alphaBetaCuts + 1.
									generator recycleMoveList: moveList.
									^bestScore]]]].
	transTable 
		storeBoard: theBoard
		value: bestScore
		type: (ValueAccurate bitOr: (ply bitAnd: 1))
		depth: 0
		stamp: stamp.
	generator recycleMoveList: moveList.
	^bestScore