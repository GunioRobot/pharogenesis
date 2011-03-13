tearOffTileForSelf
	| tiles |
	self currentHand attachMorph: (tiles _ self tileReferringToSelf).
	(tiles respondsTo: #cursorBaseOffset) ifTrue: [
		tiles align: tiles topLeft 
			 with: self currentHand position + tiles cursorBaseOffset].
