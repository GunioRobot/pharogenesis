mouseDown: evt

	((owner isKindOf: ChineseCheckers)
		and: [owner okToPickUpPieceAt: boardLoc])
		ifTrue: [evt hand grabMorph: self]