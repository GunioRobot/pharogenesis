defineIntermediatePoint
	"Define an intermediate point for an extreme change in direction"
	| pt |
	pt _ self class on: position.
	pt width: self width.
	pt prevPoint: self.
	pt nextPoint: next.
	next ifNotNil:[next prevPoint: pt].
	self nextPoint: pt.
	pt isFinal: self isFinal.