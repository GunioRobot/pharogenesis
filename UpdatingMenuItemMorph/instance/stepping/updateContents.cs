updateContents
	| newString enablement nArgs |
	wordingProvider ifNil:[^self].
	wordingSelector ifNotNil:[
		newString _ contents.
		nArgs _ wordingSelector numArgs.
		nArgs == 0 ifTrue:[newString _ wordingProvider perform: wordingSelector].
		nArgs == arguments size ifTrue:[
			newString _ wordingProvider perform: wordingSelector withArguments: arguments].
		newString = contents ifFalse: [self contents: newString]].
	enablementSelector ifNotNil:[
		(enablement _ self enablement) == isEnabled 
			ifFalse:[self isEnabled: enablement]]