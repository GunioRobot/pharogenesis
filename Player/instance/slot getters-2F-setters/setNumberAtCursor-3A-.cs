setNumberAtCursor: aNumber
	"Place the given number into the morph residing at my costume's current cursor position"

	| renderedMorph aCostume |
	aCostume _ self costume.
	((renderedMorph _ aCostume renderedMorph) respondsTo: #valueAtCursor:) ifTrue: [^ renderedMorph valueAtCursor setNumericValue: aNumber]