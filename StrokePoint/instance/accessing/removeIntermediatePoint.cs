removeIntermediatePoint
	"Remove an intermediate point for an extreme change in direction"
	next ifNil:[^self].
	prev ifNil:[^self].
	next position = self position ifTrue:[
		next _ next nextPoint.
		next ifNotNil:[next prevPoint: self].
		^self removeIntermediatePoint]