lookAtHand
	| hand |
	self isInWorld ifFalse: [^ self].
	hand := (self world activeHand) ifNil: [self world primaryHand].
	self lookAtMorph: hand