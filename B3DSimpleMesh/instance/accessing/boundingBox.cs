boundingBox
	^bBox ifNil:[bBox _ self computeBoundingBox]