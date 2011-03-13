emitCodeForIndexOf: aTempVariableNode stack: stack encoder: encoder
	self assert: encoder supportsClosureOpcodes not.
	(encoder encodeLiteral: (remoteTemps indexOf: aTempVariableNode))
		emitCodeForValue: stack encoder: encoder