allMovesFrom: boardLoc  "boardLoc must be occupied"
	| team stepMoves jumpDict |
	team := self at: boardLoc.
	stepMoves := (sixDeltas collect: [:d | boardLoc + d])
		select: [:p | (self at: p) notNil and: [(self at: p) = 0]].
	jumpDict := Dictionary new.
	jumpDict at: boardLoc put: (Array with: boardLoc).
	self jumpFor: team from: boardLoc havingVisited: jumpDict.
	jumpDict removeKey: boardLoc.
	^ (stepMoves collect: [:p | {boardLoc. p}]) , jumpDict values
		reject:
		[:move |  "Don't include any moves that land in other homes."
		(self distFrom: move last to: self boardCenter) >= 5  "In a home..."
			and: [(self distFrom: move last to: (homes atWrap: team+3)) > 3  "...not my goal..."
			and: [(self distFrom: move last to: (homes at: team)) > 3  "...nor my home"]]]