ngSearch: theBoard depth: depth alpha: initialAlpha beta: initialBeta 
	"A basic alpha-beta algorithm; based on negaMax rather than from the text books"

	| move score alpha entry bestScore moveList newBoard beta a b notFirst |
	self assert: [initialAlpha < initialBeta].
	ply < 10 ifTrue: [(variations at: ply + 1) at: 1 put: 0].
	depth = 0 
		ifTrue: 
			[^self 
				quiesce: theBoard
				alpha: initialAlpha
				beta: initialBeta].
	nodesVisited := nodesVisited + 1.
	"See if there's already something in the transposition table. If so, skip the entire search."
	entry := transTable lookupBoard: theBoard.
	alpha := initialAlpha.
	beta := initialBeta.
	(entry isNil or: [entry depth < depth]) 
		ifFalse: 
			[ttHits := ttHits + 1.
			(entry valueType bitAnd: 1) = (ply bitAnd: 1) 
				ifTrue: [beta := entry value max: initialBeta]
				ifFalse: [alpha := 0 - entry value max: initialAlpha].
			beta > initialBeta ifTrue: [^beta].
			alpha >= initialBeta ifTrue: [^alpha]].
	bestScore := AlphaBetaMinVal.

	"Generate new moves"
	moveList := generator findPossibleMovesFor: theBoard activePlayer.
	moveList ifNil: [^0 - AlphaBetaIllegal].
	moveList isEmpty 
		ifTrue: 
			[generator recycleMoveList: moveList.
			^bestScore].

	"Sort move list according to history heuristics"
	moveList sortUsing: historyTable.

	"And search"
	a := alpha.
	b := beta.
	notFirst := false.
	[(move := moveList next) isNil] whileFalse: 
			[newBoard := (boardList at: ply + 1) copyBoard: theBoard.
			newBoard nextMove: move.
			"Search recursively"
			ply := ply + 1.
			score := 0 - (self 
								ngSearch: newBoard
								depth: depth - 1
								alpha: 0 - b
								beta: 0 - a).
			(notFirst and: [score > a and: [score < beta and: [depth > 1]]]) 
				ifTrue: 
					[score := 0 - (self 
										ngSearch: newBoard
										depth: depth - 1
										alpha: 0 - beta
										beta: 0 - score)].
			notFirst := true.
			ply := ply - 1.
			stopThinking 
				ifTrue: 
					[generator recycleMoveList: moveList.
					^score].
			score = AlphaBetaIllegal 
				ifFalse: 
					[score > bestScore 
						ifTrue: 
							[ply < 10 ifTrue: [self copyVariation: move].
							bestScore := score].
					score > a 
						ifTrue: 
							[a := score.
							a >= beta 
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
									^score]].
					b := a + 1]].
	transTable 
		storeBoard: theBoard
		value: bestScore
		type: (ValueAccurate bitOr: (ply bitAnd: 1))
		depth: depth
		stamp: stamp.
	generator recycleMoveList: moveList.
	^bestScore