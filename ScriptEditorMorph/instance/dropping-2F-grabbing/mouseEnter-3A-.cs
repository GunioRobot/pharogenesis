mouseEnter: evt
	| hand tile |
	hand _ evt hand.
	(hand submorphs size = 1 and: [hand lastEvent redButtonPressed]) ifTrue:
		[tile _ hand firstSubmorph.
		(self wantsDroppedMorph: tile) ifTrue:
			[(tile isKindOf: PhraseTileMorph) ifTrue: [tile brightenTiles].
			self startStepping]].