normalSend: tMeth type: type

	| nArgs rcvr rcvrClass |
	self inline: true.

	self assertIsTranslatedMethod: tMeth.
	nArgs _ self fetchPointer: MethodArgCountIndex ofObject: tMeth.
	nArgs _ self integerValueOf: nArgs.
	rcvr _ self internalStackValue: nArgs.
	rcvrClass _ self fetchClassOf: rcvr.
	self checkSend: tMeth to: rcvr data: rcvrClass nArgs: nArgs type: type