boundingBox
	|bBox|
	box ifNotNil:[^box].
	bBox _ nil.
	objects do:[:obj|
		bBox _ bBox ifNil:[obj boundingBox] ifNotNil:[bBox merge: obj boundingBox]
	].
	^box _ bBox