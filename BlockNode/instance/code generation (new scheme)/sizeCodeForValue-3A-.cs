sizeCodeForValue: encoder
	self generateAsClosure ifTrue:
		[^self sizeCodeForClosureValue: encoder].

	nArgsNode := encoder encodeLiteral: arguments size.
	remoteCopyNode := encoder encodeSelector: #blockCopy:.
	size := self sizeCodeForEvaluatedValue: encoder.
	self returns ifFalse:
		[size := size + encoder sizeReturnTopToCaller]. "endBlock"
	arguments := arguments collect:  "Chance to prepare debugger remote temps"
						[:arg | arg asStorableNode: encoder].
	arguments do: [:arg | size := size + (arg sizeCodeForStorePop: encoder)].
	^encoder sizePushThisContext
	 + (nArgsNode sizeCodeForValue: encoder) 
	 + (remoteCopyNode sizeCode: encoder args: 1 super: false)
	 + (encoder sizeJumpLong: size)
	 + size