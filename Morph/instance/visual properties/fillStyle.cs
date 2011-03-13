fillStyle
	"Return the current fillStyle of the receiver."
	extension ifNil:[^color ifNil:[self defaultColor]].
	^self valueOfProperty: #fillStyle ifAbsent:[
		"Workaround already converted morphs"
		color ifNil:[self defaultColor]].