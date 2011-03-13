mustDeclareVariableWording
	
	^ mustDeclareVariables
		ifTrue: ['<yes> automatically create variable declaration' translated]
		ifFalse: ['<no> automatically create variable declaration' translated]