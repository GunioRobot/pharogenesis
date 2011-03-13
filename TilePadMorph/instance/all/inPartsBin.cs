inPartsBin

	| o |
	o _ self owner.
	[o == nil] whileFalse: [
		(o isKindOf: PartsBinMorph) ifTrue: [^ true].
		o _ o owner].
	^ false
