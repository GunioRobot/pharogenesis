inPartsBin
	| o |
	self isPartsDonor ifTrue: [^ true].

	o _ self owner.
	[o == nil] whileFalse:
		[o isPartsBin ifTrue: [^ true].
		o _ o owner].
	^ false
