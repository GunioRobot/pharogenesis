findQuiescenceMovesFor: player
	"Find all the quiescence moves (that is moves capturing pieces)"
	forceCaptures _ true.
	^self findAllPossibleMovesFor: player.