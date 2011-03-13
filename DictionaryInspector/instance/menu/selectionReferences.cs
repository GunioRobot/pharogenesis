selectionReferences
	"Create a browser on all references to the association of the current selection."

	self selectionIndex = 0 ifTrue: [^ self changed: #flash].
	object class == MethodDictionary ifTrue: [^ self changed: #flash].
	Smalltalk browseAllCallsOn: (object associationAt: (keyArray at: selectionIndex)).
