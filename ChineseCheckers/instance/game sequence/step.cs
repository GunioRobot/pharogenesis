step
	whoseMove = 0 ifTrue: [^self].	"Game over."
	plannedMove isNil 
		ifTrue: 
			[(autoPlay at: whoseMove) ifFalse: [^self].	"Waiting for a human."
			plannedMove := (self endGameFor: whoseMove) 
						ifTrue: 
							["Look deeper at the end."

							self bestMove: 2 forTeam: whoseMove]
						ifFalse: [self bestMove: 1 forTeam: whoseMove].
			movePhase := 1	"Start the animated move"].
	animateMoves 
		ifTrue: 
			["Display the move in phases..."

			movePhase > 0 ifTrue: [^self showNextMoveSegment]]
		ifFalse: 
			["... or skip the entire animated move if requested."

			self makeMove: plannedMove.
			(self pieceAt: plannedMove first)
				position: (self cellPointAt: plannedMove last);
				setBoard: self loc: plannedMove last.
			self changed.
			movePhase := 0].
	plannedMove := nil.	"End the animated move"
	self nextTurn