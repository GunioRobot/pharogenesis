evaluateUnloggedForSelf: aCodeString

	^Compiler evaluate:
		aCodeString
		for: self
		logged: false