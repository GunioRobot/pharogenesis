compactSend: tMeth type: type

	| nArgs rcvr rcvrClass |
	self inline: true.

	self assertIsTranslatedMethod: tMeth.
	nArgs _ self fetchPointer: MethodArgCountIndex ofObject: tMeth.
	nArgs _ self integerValueOf: nArgs.
	rcvr _ self internalStackValue: nArgs.
	(self isIntegerObject: rcvr)
		ifTrue: [rcvrClass _ 0]
		ifFalse: [rcvrClass _ ((self baseHeader: rcvr) bitAnd: 16r1F000) + 1].
	self checkSend: tMeth to: rcvr data: rcvrClass nArgs: nArgs type: type