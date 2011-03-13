emitCCodeOn: aStream level: level generator: aCodeGen

	| sel |
	self isVariableUpdatingAssignment ifTrue: [
		variable emitCCodeOn: aStream level: level generator: aCodeGen.
		sel _ expression selector.
		sel = #+
			ifTrue: [aStream nextPutAll: ' += ']
			ifFalse: [aStream nextPutAll: ' -= '].
			expression args first emitCCodeOn: aStream level: level generator: aCodeGen.
	] ifFalse: [
		variable emitCCodeOn: aStream level: level generator: aCodeGen.
		aStream nextPutAll: ' = '.
		expression emitCCodeOn: aStream level: level generator: aCodeGen.
	].