methodStringsContainingit
	"Open a browser on methods which contain the current selection as part of a string constant.  2/1/96 sw"

	startBlock = stopBlock ifTrue: [view flash.  ^ self].
	Cursor wait showWhile:
		[self terminateAndInitializeAround: [Smalltalk browseMethodsWithString: self selection string]].
	Cursor normal show