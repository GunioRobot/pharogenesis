donorActor: player1 ownActor: player2
	player _ player2.
	currentScriptEditor ifNotNil: [currentScriptEditor donorActor: player1 ownActor: player2].
	self allScriptVersionsDo: [:anEditor | anEditor donorActor: player1 ownActor: player2]