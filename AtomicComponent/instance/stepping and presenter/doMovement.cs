doMovement
	| distances direction |
	self
		position: (owner fastMoves
				ifTrue: [futurePosition]
				ifFalse: [distances _ futurePosition - self position.
					direction _ distances x sign @ distances y sign.
					self position + (direction + (distances // 6))])