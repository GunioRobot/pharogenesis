initFromPinSpecs
	| ioPin |
	ioPin _ pinSpecs first.
	ioPin isInput ifTrue: [getTextSelector _ ioPin modelReadSelector]
					ifFalse: [getTextSelector _ nil].
	ioPin isOutput ifTrue: [setTextSelector _ ioPin modelWriteSelector]
					ifFalse: [setTextSelector _ nil].
