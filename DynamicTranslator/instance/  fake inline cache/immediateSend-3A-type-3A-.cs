immediateSend: tMeth type: type

	| nArgs rcvr |
	self inline: true.

	self assertIsTranslatedMethod: tMeth.
	nArgs _ self fetchPointer: MethodArgCountIndex ofObject: tMeth.
	nArgs _ self integerValueOf: nArgs.
	rcvr _ self internalStackValue: nArgs.
	self checkSend: tMeth to: rcvr data: (rcvr bitAnd: 1) nArgs: nArgs type: type