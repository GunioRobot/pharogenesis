step

	whoseMove = 0 ifTrue: [^ self].  "Game over."

	plannedMove == nil ifTrue:
		[(autoPlay at: whoseMove) ifFalse: [^ self].  "Waiting for a human."
		(self endGameFor: whoseMove)  "Look deeper at the end."
			ifTrue: [plannedMove _ self bestMove: 2 forTeam: whoseMove]
			ifFalse: [plannedMove _ self bestMove: 1 forTeam: whoseMove].
		movePhase _ 1.  "Start the animated move"].

	animateMoves
		ifTrue: ["Display the move in phases..."
				movePhase > 0 ifTrue: [^ self showNextMoveSegment]]
		ifFalse: ["... or skip the entire animated move if requested."
				self makeMove: plannedMove.
				(self pieceAt: plannedMove first)
						position: (self cellPointAt: plannedMove last);
						setBoard: self loc: plannedMove last.
				self changed.
				movePhase _ 0].

	plannedMove _ nil.  "End the animated move"

	self nextTurn