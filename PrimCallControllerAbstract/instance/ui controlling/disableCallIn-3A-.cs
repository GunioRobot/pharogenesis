disableCallIn: aMethodRef 
	"Disables enabled external prim call."
	(self existsEnabledCallIn: aMethodRef)
		ifFalse: [self changeStatusOfFailedCallsFlag
				ifTrue: [(self existsFailedCallIn: aMethodRef)
						ifFalse: [^ self error: 'no enabled or failed prim call found']]
				ifFalse: [^ self error: 'no enabled prim call found']].
	self privateDisableCallIn: aMethodRef.
	self treatedMethods at: aMethodRef put: #disabled.
	self logStream
		ifNotNil: [self log: 'Call ' , (self extractCallModuleNames: aMethodRef) printString , ' in ' , aMethodRef actualClass name , '>>' , aMethodRef methodSymbol , ' disabled.']