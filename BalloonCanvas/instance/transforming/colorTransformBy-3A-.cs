colorTransformBy: aColorTransform
	aColorTransform ifNil:[^self].
	colorTransform 
		ifNil:[colorTransform _ aColorTransform]
		ifNotNil:[colorTransform _ colorTransform composedWithLocal: aColorTransform]