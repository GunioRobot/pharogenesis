split: aString 
	| formatted |
	formatted _ sourceClass compilerClass new
format: aString
				in: sourceClass
				notifying: nil
				decorated: false.
	^super split: formatted