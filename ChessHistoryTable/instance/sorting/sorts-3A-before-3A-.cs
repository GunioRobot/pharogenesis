sorts: move1 before: move2
	^(self at: (move1 sourceSquare bitShift: 6) + move1 destinationSquare) >
		(self at: (move2 sourceSquare bitShift: 6) + move2 destinationSquare)