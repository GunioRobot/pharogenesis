getNumberAtCursor
	"Answer the number borne by the object at my costume's current cursor position"

	| renderedMorph aCostume |
	aCostume _ self costume.
	((renderedMorph _ aCostume renderedMorph) respondsTo: #valueAtCursor:) ifTrue: [^ renderedMorph valueAtCursor getNumericValue]