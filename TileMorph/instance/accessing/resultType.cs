resultType
	"Answer the result type of the receiver"

	type == #literal 
		ifTrue: 
			[(literal isNumber) ifTrue: [^#Number].
			(literal isString) ifTrue: [^#String].
			(literal isKindOf: Boolean) ifTrue: [^#Boolean]].
	type == #expression ifTrue: [^#Number].
	type == #objRef ifTrue: [^#Player].
	^#unknown