nameForViewer
	"Answer a name to be shown in a Viewer that is viewing the receiver"

	| aName |
	(aName _ self uniqueNameForReferenceOrNil) ifNotNil: [^ aName].

	^ (self printString copyWithout: Character cr) withNoLineLongerThan:  20