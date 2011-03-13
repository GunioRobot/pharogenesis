mouseEnter: evt
	| hand tile |

	self flag: #bob.		"needed renderedMorph due to transformations"
	hand _ evt hand.
	hand submorphs size = 1 ifFalse: [^self].
	evt "hand lastEvent" redButtonPressed ifFalse: [^self].
	tile _ hand firstSubmorph renderedMorph.
	(self wantsDroppedMorph: tile event: evt) ifFalse: [^self].
	(tile isKindOf: PhraseTileMorph) ifTrue: [tile brightenTiles]. 
	handWithTile _ hand.
	self startStepping