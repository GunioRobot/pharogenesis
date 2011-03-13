initFromPinSpecs
	| ioPin |
	getListSelector _ pinSpecs first modelReadSelector.
	ioPin _ pinSpecs second.
	ioPin isInput ifTrue: [getIndexSelector _ ioPin modelReadSelector]
					ifFalse: [getIndexSelector _ nil].
	ioPin isOutput ifTrue: [setIndexSelector _ ioPin modelWriteSelector]
					ifFalse: [setIndexSelector _ nil].
	setSelectionSelector _ pinSpecs third modelWriteSelector.
