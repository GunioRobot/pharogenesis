methodNamesContainingIt
	"Open a browser on methods names containing the selected string.  1/17/96 sw"

	startBlock = stopBlock ifTrue: [view flash.  ^ self].
	Cursor wait showWhile:
		[self terminateAndInitializeAround: [Smalltalk browseMethodsWhoseNamesContain: self selection string]].
	Cursor normal show