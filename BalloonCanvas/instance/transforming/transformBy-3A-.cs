transformBy: aTransform
	aTransform ifNil:[^self].
	transform 
		ifNil:[transform _ aTransform]
		ifNotNil:[transform _ transform composedWithLocal: aTransform]