lookAtHand
	| hand |
	self isInWorld ifFalse: [^ self].
	hand _ (self world activeHand) ifNil: [self world primaryHand].
	self lookAtMorph: hand