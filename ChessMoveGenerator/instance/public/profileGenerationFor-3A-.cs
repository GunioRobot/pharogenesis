profileGenerationFor: player
	| list |
	Smalltalk garbageCollect.
	MessageTally spyOn:[
		1 to: 100000 do:[:i|
			list _ self findPossibleMovesFor: player.
			self recycleMoveList: list].
	].
