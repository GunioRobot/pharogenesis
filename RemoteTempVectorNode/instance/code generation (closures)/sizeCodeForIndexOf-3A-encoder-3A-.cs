sizeCodeForIndexOf: aTempVariableNode encoder: encoder
	self assert: encoder supportsClosureOpcodes not.
	^(encoder encodeLiteral: (remoteTemps indexOf: aTempVariableNode)) sizeCodeForValue: encoder