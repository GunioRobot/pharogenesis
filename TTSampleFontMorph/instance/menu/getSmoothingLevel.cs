getSmoothingLevel
	"Menu support"
	smoothing = 1 ifTrue:[^'turn on smoothing'].
	smoothing = 2 ifTrue:[^'more smoothing'].
	smoothing = 4 ifTrue:[^'turn off smoothing'].
