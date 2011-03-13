sizeForValue: encoder
	nArgsNode := encoder encodeLiteral: arguments size.
	remoteCopyNode := encoder encodeSelector: #blockCopy:.
	size := (self sizeForEvaluatedValue: encoder)
				+ (self returns ifTrue: [0] ifFalse: [1]). "endBlock"
	arguments := arguments collect:  "Chance to prepare debugger remote temps"
				[:arg | arg asStorableNode: encoder].
	arguments do: [:arg | size := size + (arg sizeForStorePop: encoder)].
	^1 + (nArgsNode sizeForValue: encoder) 
		+ (remoteCopyNode size: encoder args: 1 super: false) + 2 + size