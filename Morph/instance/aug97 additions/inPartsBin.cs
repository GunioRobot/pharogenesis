inPartsBin
	| o |
	(self hasProperty: #partsDonor) ifTrue: [^ true].

	o _ self owner.
	[o == nil] whileFalse:
		[o isPartsBin ifTrue: [^ true].
		o _ o owner].
	^ false
