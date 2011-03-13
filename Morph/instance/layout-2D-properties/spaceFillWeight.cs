spaceFillWeight
	"Layout specific. This property describes the relative weight that should be given to the receiver when extra space is distributed between different #spaceFill cells."
	extension == nil ifTrue:[^1]. "get out quickly"
	^self valueOfProperty: #spaceFillWeight ifAbsent:[1]