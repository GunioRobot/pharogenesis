send: selector super: superFlag numArgs: numArgs

	selector == #toBraceStack:
		ifFalse: [self error: 'Malformed brace-variable code'].
	elements at: initIndex put:
		(BraceConstructor new
			codeBrace: subBraceSize
			fromBytes: decompiler
			withConstructor: constructor).
	initIndex _ initIndex - 1