getClassForNewImplementationOf: sel 
	| className |
	className := (OBTextRequest 
				prompt: 'Please type class name in which to implement ' , sel
				template: '') ifNil: [''].
	^(Smalltalk classNamed: className withBlanksTrimmed) ifNil: 
			[self inform: 'Class ' , className , ' not found'.
			nil]