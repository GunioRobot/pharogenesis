enableCallIn: aMethodRef 
	"Enables disabled external prim call."
	(self existsDisabledCallIn: aMethodRef)
		ifTrue: [self privateEnableCallIn: aMethodRef]
		ifFalse: [self changeStatusOfFailedCallsFlag
				ifTrue: [(self existsFailedCallIn: aMethodRef)
						ifTrue: [self privateEnableViaLiteralIn: aMethodRef]
						ifFalse: [^ self error: 'no disabled or failed prim call found']]
				ifFalse: [^ self error: 'no disabled prim call found']].
	self treatedMethods at: aMethodRef put: #enabled.
	self logStream
		ifNotNil: [self log: 'Call ' , (self extractCallModuleNames: aMethodRef) printString , ' in ' , aMethodRef actualClass name , '>>' , aMethodRef methodSymbol , ' enabled.']