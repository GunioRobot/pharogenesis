getSmoothingLevel
	"Menu support"
	| aaLevel |
	aaLevel _ self defaultAALevel ifNil:[1].
	aaLevel = 1 ifTrue:[^'turn on smoothing'].
	aaLevel = 2 ifTrue:[^'more smoothing'].
	aaLevel = 4 ifTrue:[^'turn off smoothing'].
