boundingBox
	| bBox |
	bBox _ geometry ifNotNil:[geometry boundingBox].
	children ifNil:[^bBox].
	children do:[:obj|
		bBox _ bBox ifNil:[obj boundingBox] ifNotNil:[bBox merge: obj boundingBox]
	].
	^bBox