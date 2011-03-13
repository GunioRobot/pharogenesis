inspectorKey: aChar from: view
	"respond to a Command key.  Got here from a list of fields being inspected"

	aChar == $i ifTrue: [self selection inspect].
	aChar == $c ifTrue: [self copyName].
	^ self arrowKey: aChar from: view