forwardDirection
	"Same as rotationDegrees"
| m |
^ (((m _ self renderedMorph) isKindOf: SketchMorph) and: [m rotationStyle ~~ #normal]) 
			ifTrue: [m rotationDegrees]
			ifFalse: [self angle radiansToDegrees negated]