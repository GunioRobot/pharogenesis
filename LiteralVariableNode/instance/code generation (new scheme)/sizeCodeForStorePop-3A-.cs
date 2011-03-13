sizeCodeForStorePop: encoder
	self reserve: encoder.
	^(key isVariableBinding and: [key isSpecialWriteBinding])
		ifTrue: [(self sizeCodeForStorePop: encoder) + encoder sizePop]
		ifFalse: [encoder sizeStorePopLiteralVar: index]