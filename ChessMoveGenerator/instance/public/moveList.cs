moveList
	| list |
	kingAttack ifNotNil:[
		lastMoveIndex _ firstMoveIndex.
		^nil].
	list _ streamList at: (streamListIndex _ streamListIndex + 1).
	list on: moveList from: firstMoveIndex+1 to: lastMoveIndex.
	firstMoveIndex _ lastMoveIndex.
	^list