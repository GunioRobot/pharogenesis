faceNormals
	^faceNormals ifNil:[faceNormals _ self computeFaceNormals]