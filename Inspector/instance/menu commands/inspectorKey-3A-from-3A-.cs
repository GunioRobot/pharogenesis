inspectorKey: aChar from: view
	"respond to a Command key.  Got here from a list of fields being inspected"

	aChar == $i ifTrue: [self selection inspect].
	aChar == $I ifTrue: [self selection explore].
	aChar == $b ifTrue:	[self browseMethodFull].
	aChar == $c ifTrue: [self copyName].
	^ self arrowKey: aChar from: view