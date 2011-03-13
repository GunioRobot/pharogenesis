doLayoutIn: layoutBounds
	"layout has changed. update scroll deltas or whatever else"
	self valueOfProperty: #maxAutoFitSize ifPresentDo:
		[:maxFitSize |
		self fitContentsUpTo: maxFitSize.
		^super doLayoutIn: layoutBounds].
	scroller ifNotNil: [self setScrollDeltas].
	super doLayoutIn: layoutBounds.