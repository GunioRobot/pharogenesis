makePointwithxValue: xValue yValue: yValue

	| pointResult |
	pointResult _ self instantiateSmallClass: (self splObj: ClassPoint)
							   sizeInBytes: 12
									   fill: nilObj.
	self storePointer: XIndex ofObject: pointResult withValue: (self integerObjectOf: xValue).
	self storePointer: YIndex ofObject: pointResult withValue: (self integerObjectOf: yValue).
	^ pointResult