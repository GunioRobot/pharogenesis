pieceAt: boardLoc

	self submorphsDo:
		[:m | ((m isMemberOf: ChineseCheckerPiece) and: [m boardLoc = boardLoc])
				ifTrue: [^ m]].
	^ nil