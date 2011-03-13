outerBounds
	"Return the 'outer' bounds of the receiver, e.g., the bounds that need to be invalidated when the receiver changes."
	| box |
	box _ self bounds.
	self hasDropShadow ifTrue:[box _ self expandFullBoundsForDropShadow: box].
	self hasRolloverBorder ifTrue:[box _ self expandFullBoundsForRolloverBorder: box].
	^box