selectionReferences
	"Create a browser on all references to the association of the current selection."

	model selectionIndex = 0
		ifTrue: [^view flash].
	self controlTerminate.
	Smalltalk browseAllCallsOn: model selectionAssociation.
	self startUp.