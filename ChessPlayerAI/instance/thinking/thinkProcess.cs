thinkProcess
	| score theMove depth |
	stopThinking := false.
	score := board activePlayer evaluate.
	depth := 1.
	stamp := stamp + 1.
	ply := 0.
	historyTable clear.
	transTable clear.
	startTime := Time millisecondClockValue.
	nodesVisited := ttHits := alphaBetaCuts := 0.
	bestVariation at: 1 put: 0.
	activeVariation at: 1 put: 0.
	[nodesVisited < 50000] whileTrue: 
			["whats this ? (aoy)  false ifTrue:[] ????!"

			theMove := false 
						ifTrue: 
							[self 
								mtdfSearch: board
								score: score
								depth: depth]
						ifFalse: 
							[self 
								negaScout: board
								depth: depth
								alpha: AlphaBetaMinVal
								beta: AlphaBetaMaxVal].
			theMove ifNil: [^myProcess := nil].
			stopThinking ifTrue: [^myProcess := nil].
			myMove := theMove.
			bestVariation 
				replaceFrom: 1
				to: bestVariation size
				with: activeVariation
				startingAt: 1.
			score := theMove value.
			depth := depth + 1].
	myProcess := nil