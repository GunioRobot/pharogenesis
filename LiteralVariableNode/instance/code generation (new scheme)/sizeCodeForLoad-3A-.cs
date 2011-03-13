sizeCodeForLoad: encoder
	^writeNode ifNil: [0] ifNotNil: [encoder sizePushLiteral: index]