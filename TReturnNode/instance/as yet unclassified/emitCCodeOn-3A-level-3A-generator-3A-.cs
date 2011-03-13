emitCCodeOn: aStream level: level generator: aCodeGen

	aStream nextPutAll: 'return '.
	expression emitCCodeOn: aStream level: level generator: aCodeGen.