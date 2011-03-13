referencePosition: aPosition
	"Move the receiver to match its reference position with aPosition"
	| newPos intPos |
	newPos _ self position + (aPosition - self referencePosition).
	intPos _ newPos asIntegerPoint.
	newPos = intPos 
		ifTrue:[self position: intPos]
		ifFalse:[self position: newPos].