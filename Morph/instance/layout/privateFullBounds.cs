privateFullBounds
	"Private. Compute the actual full bounds of the receiver"
	| box |
	submorphs size = 0 ifTrue: [^self outerBounds].
	box _ self outerBounds copy.
	self clipSubmorphs
		ifTrue:[box _ box quickMerge: (self submorphBounds intersect: self clippingBounds)]
		ifFalse:[box _ box quickMerge: self submorphBounds].
	^ box origin asIntegerPoint corner: box corner asIntegerPoint
