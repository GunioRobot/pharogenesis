oldCompactSend: tMeth type: type

	| nArgs rcvr prevClass rcvrClass |
	self inline: true.

	self assertIsTranslatedMethod: tMeth.
	nArgs _ self fetchPointer: MethodArgCountIndex ofObject: tMeth.
	nArgs _ self integerValueOf: nArgs.
	rcvr _ self internalStackValue: nArgs.
	prevClass _ (self fetchPointer: MethodLinkageIndex ofObject: tMeth) - 1.
	self assert: prevClass ~= 0.
	(self isIntegerObject: rcvr)
		ifTrue: [rcvrClass _ 0]
		ifFalse: [rcvrClass _ ((self baseHeader: rcvr) bitAnd: 16r1F000)].
	(rcvrClass = prevClass) ifTrue: [
		self executeLinkedSend: tMeth to: rcvr nArgs: nArgs.
	] ifFalse: [
		self relinkSend: tMeth to: rcvr nArgs: nArgs type: type.
	]