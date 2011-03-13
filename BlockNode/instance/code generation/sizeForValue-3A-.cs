sizeForValue: encoder
	nArgsNode _ encoder encodeLiteral: arguments size.
	remoteCopyNode _ encoder encodeSelector: #blockCopy:.
	size _ (self sizeForEvaluatedValue: encoder)
				+ (self returns ifTrue: [0] ifFalse: [1]). "endBlock"
	arguments _ arguments collect:  "Chance to prepare debugger remote temps"
				[:arg | arg asStorableNode: encoder].
	arguments do: [:arg | size _ size + (arg sizeForStorePop: encoder)].
	^1 + (nArgsNode sizeForValue: encoder) 
		+ (remoteCopyNode size: encoder args: 1 super: false) + 2 + size