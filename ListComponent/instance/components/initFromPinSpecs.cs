initFromPinSpecs
	| ioPin |
	getListSelector := pinSpecs first modelReadSelector.
	ioPin := pinSpecs second.
	getIndexSelector := ioPin isInput 
		ifTrue: [ioPin modelReadSelector]
		ifFalse: [nil].
	setIndexSelector := ioPin isOutput 
				ifTrue: [ioPin modelWriteSelector]
				ifFalse: [nil].
	setSelectionSelector := pinSpecs third modelWriteSelector