boundingBox
 "copied from B3DIndexMesh"
	^bBox ifNil:[bBox _ self computeBoundingBox]