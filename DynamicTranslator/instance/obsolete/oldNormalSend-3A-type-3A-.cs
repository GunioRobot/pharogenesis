oldNormalSend: tMeth type: type

	| nArgs rcvr prevClass rcvrClass |
	self inline: true.

	self assertIsTranslatedMethod: tMeth.
	nArgs _ self fetchPointer: MethodArgCountIndex ofObject: tMeth.
	nArgs _ self integerValueOf: nArgs.
	rcvr _ self internalStackValue: nArgs.
	prevClass _ self fetchPointer: MethodLinkageIndex ofObject: tMeth.
	rcvrClass _ self fetchClassOf: rcvr.
	(rcvrClass = prevClass) ifTrue: [
		self executeLinkedSend: tMeth to: rcvr nArgs: nArgs.
	] ifFalse: [
		self relinkSend: tMeth to: rcvr nArgs: nArgs type: type.
	]