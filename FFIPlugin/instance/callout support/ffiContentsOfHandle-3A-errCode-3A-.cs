ffiContentsOfHandle: oop errCode: errCode
	"Make sure that the given oop is a valid external handle"
	self inline: true.
	(interpreterProxy isIntegerObject: oop)
		ifTrue:[^self ffiFail: errCode].
	(interpreterProxy isBytes: oop)
		ifFalse:[^self ffiFail: errCode].
	((interpreterProxy byteSizeOf: oop) == 4)
		ifFalse:[^self ffiFail: errCode].
	^interpreterProxy fetchWord: 0 ofObject: oop