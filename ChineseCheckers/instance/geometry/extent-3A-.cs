extent: newExtent

	| extraY |
	extraY _ (newExtent x / 15.0 * 1.25) asInteger.
	super extent: (newExtent x) @ (newExtent x + extraY).
	self submorphsDo:
		[:m | (m isKindOf: ChineseCheckerPiece) ifTrue:
				[m position: (self cellPointAt: m boardLoc); extent: self pieceSize]]