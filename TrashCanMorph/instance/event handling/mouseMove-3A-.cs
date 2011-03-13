mouseMove: evt
	| hand firstSub |
	hand _ evt hand.
	(((hand submorphCount > 0) and: [(firstSub _ hand submorphs first) ~~ self]) and:
			[self wantsDroppedMorph: firstSub event: evt])
		ifTrue: 
			[super mouseMove: evt]
