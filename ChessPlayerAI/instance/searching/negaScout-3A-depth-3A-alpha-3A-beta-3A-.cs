negaScout: theBoard depth: depth alpha: initialAlpha beta: initialBeta 
	"Modified version to return the move rather than the score"
	| move score alpha bestScore moveList newBoard beta goodMove a b notFirst |
	self
		assert: [initialAlpha < initialBeta].
	ply < 10
		ifTrue: [(variations at: ply + 1)
				at: 1
				put: 0].
	ply _ 0.
	alpha _ initialAlpha.
	beta _ initialBeta.
	bestScore _ AlphaBetaMinVal.
	"Generate new moves"
	moveList _ generator findPossibleMovesFor: theBoard activePlayer.
	moveList
		ifNil: [^ nil].
	moveList size = 0
		ifTrue: [generator recycleMoveList: moveList.
			^ nil].
	"Sort move list according to history heuristics"
	moveList sortUsing: historyTable.
	"And search"
	a _ alpha.
	b _ beta.
	notFirst _ false.
	[(move _ moveList next) isNil]
		whileFalse: [newBoard _ (boardList at: ply + 1)
						copyBoard: theBoard.
			newBoard nextMove: move.
			"Search recursively"
			"Search recursively"
			ply _ ply + 1.
			score _ 0
						- (self
								ngSearch: newBoard
								depth: depth - 1
								alpha: 0 - b
								beta: 0 - a).
			(notFirst
					and: [score > a
							and: [score < beta
									and: [depth > 1]]])
				ifTrue: [score _ 0
								- (self
										ngSearch: newBoard
										depth: depth - 1
										alpha: 0 - beta
										beta: 0 - score)].
			notFirst _ true.
			ply _ ply - 1.
			stopThinking
				ifTrue: [generator recycleMoveList: moveList.
					^ move].
			score = AlphaBetaIllegal
				ifFalse: [score > bestScore
						ifTrue: [ply < 10
								ifTrue: [self copyVariation: move].
							goodMove _ move copy.
							goodMove value: score.
							activeVariation
								replaceFrom: 1
								to: activeVariation size
								with: variations first
								startingAt: 1.
							bestScore _ score].
					"See if we can cut off the search"
					score > a
						ifTrue: [a _ score.
							a >= beta
								ifTrue: [transTable
										storeBoard: theBoard
										value: score
										type: (ValueBoundary
												bitOr: (ply bitAnd: 1))
										depth: depth
										stamp: stamp.
									historyTable addMove: move.
									alphaBetaCuts _ alphaBetaCuts + 1.
									generator recycleMoveList: moveList.
									^ goodMove]].
					b _ a + 1]].
	transTable
		storeBoard: theBoard
		value: bestScore
		type: (ValueAccurate
				bitOr: (ply bitAnd: 1))
		depth: depth
		stamp: stamp.
	generator recycleMoveList: moveList.
	^ goodMove