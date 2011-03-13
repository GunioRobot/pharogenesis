quickMethod
	^ method isReturnSpecial
		ifTrue: [constructor codeBlock:
				(Array with: (constTable at: method primitive - 255)) returns: true]
		ifFalse: [method isReturnField
			ifTrue: [constructor codeBlock:
				(Array with: (constructor codeInst: method returnField)) returns: true]
			ifFalse: [self error: 'improper short method']]