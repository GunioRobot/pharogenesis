proceedStoredBlock
	"Proceed decompressing a stored (e.g., uncompressed) block"
	| length decoded |
	"Literal table must be nil for a stored block"
	litTable == nil ifFalse:[^self error:'Bad state'].
	length _ distTable.
	[length > 0 and:[readLimit < collection size and:[sourcePos < sourceLimit]]] 
		whileTrue:[
			collection at: (readLimit _ readLimit + 1) put: 
				(source at: (sourcePos _ sourcePos + 1)).
			length _ length - 1].
	length = 0 ifTrue:[state _ state bitAnd: StateNoMoreData].
	decoded _ length - distTable.
	distTable _ length.
	^decoded