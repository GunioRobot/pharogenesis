initFromPinSpecs
	| ioPin |
	ioPin := pinSpecs first.
	getTextSelector := ioPin isInput 
		ifTrue: [ioPin modelReadSelector]
		ifFalse: [nil].
	setTextSelector := ioPin isOutput 
				ifTrue: [ioPin modelWriteSelector]
				ifFalse: [nil]