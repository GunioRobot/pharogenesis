acceptValue: aValue
	| newVal |
	newVal _ self acceptValueFromTarget: aValue.
	self updateContentsFrom: newVal.
	(owner isKindOf: TileMorph) ifTrue:
		[owner resizeToFitLabel]
