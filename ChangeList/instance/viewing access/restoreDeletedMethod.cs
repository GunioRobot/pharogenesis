restoreDeletedMethod
	"If lostMethodPointer is not nil, then this is a version browser for a method that has been removed.  In this case we want to establish a sourceCode link to prior versions.  We do this by installing a dummy method with the correct source code pointer prior to installing this version."
	| dummyMethod class selector |
	dummyMethod _ CompiledMethod toReturnSelf setSourcePointer: lostMethodPointer.
	class _ (changeList at: listIndex) methodClass.
	selector _ (changeList at: listIndex) methodSelector.
	class addSelector: selector withMethod: dummyMethod.
	(changeList at: listIndex) fileIn.
	"IF for some reason, the dummy remains, remove it, but (N.B.!) we might not get control back if the compile (fileIn above) fails."
	(class compiledMethodAt: selector) == dummyMethod
		ifTrue: [class removeSelectorSimply: selector].
	^ true