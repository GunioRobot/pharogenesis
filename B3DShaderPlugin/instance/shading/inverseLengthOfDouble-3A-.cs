inverseLengthOfDouble: aVector
	| scale |
	self returnTypeC:'double'.
	self var: #aVector declareC:'double * aVector'.
	self var: #scale declareC:'double scale'.
	"scale _ self dotProductOf: aVector with: aVector."
	scale _ ((aVector at: 0) * (aVector at: 0)) +
				((aVector at: 1) * (aVector at: 1)) +
					((aVector at: 2) * (aVector at: 2)).
	(scale = 0.0 or:[scale = 1.0]) ifTrue:[^scale].
	^1.0 / scale sqrt