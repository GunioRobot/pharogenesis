methodNamesContainingIt
	"Open a browser on methods names containing the selected string"

	self lineSelectAndEmptyCheck: [^ self].
	Cursor wait showWhile:
		[self terminateAndInitializeAround: [Smalltalk browseMethodsWhoseNamesContain: self selection string withBlanksTrimmed]].
	Cursor normal show