tearOffTileForSelf
	| tiles |
	self currentHand attachMorph: (tiles _ self tileReferringToSelf).
	(tiles isKindOf: SyntaxMorph) ifTrue:
		[Preferences tileTranslucentDrag
			ifTrue: [tiles lookTranslucent]
			ifFalse: [tiles align: tiles topLeft 
			 			with: self currentHand position + tiles cursorBaseOffset]]
