colorsUsed
	"Return a list of the Colors this form uses."

	| tallies tallyDepth usedColors |
	tallies _ self tallyPixelValues.
	tallyDepth _ (tallies size log: 2) asInteger.
	usedColors _ OrderedCollection new.
	tallies doWithIndex: [:count :i |
		count > 0 ifTrue: [
			usedColors add: (Color colorFromPixelValue: i - 1 depth: tallyDepth)]].
	^ usedColors asArray
