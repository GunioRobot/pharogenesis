sourcePoint
	"If we are being dragged use our center, otherwise use pointer position"
	^(trackPointer not or: [owner notNil and: [owner isHandMorph]])
		ifTrue: [self center]
		ifFalse: [self currentHand position]