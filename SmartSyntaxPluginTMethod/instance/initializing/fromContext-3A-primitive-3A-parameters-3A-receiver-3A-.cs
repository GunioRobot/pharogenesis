fromContext: aContext primitive: aString parameters: aClassList receiver: aClass

	fullArgs _ args _ aContext tempNames
				copyFrom: 1
				to: aContext method numArgs.
	self 
		primitive: aString
		parameters: aClassList
		receiver: aClass