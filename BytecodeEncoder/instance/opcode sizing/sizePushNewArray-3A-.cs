sizePushNewArray: size
	^self sizeOpcodeSelector: #genPushNewArray: withArguments: {size}