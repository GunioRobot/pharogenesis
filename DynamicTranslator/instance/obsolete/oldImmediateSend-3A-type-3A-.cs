oldImmediateSend: tMeth type: type

	| nArgs rcvr prevClass |
	self inline: true.

	self assertIsTranslatedMethod: tMeth.
	nArgs _ self fetchPointer: MethodArgCountIndex ofObject: tMeth.
	nArgs _ self integerValueOf: nArgs.
	rcvr _ self internalStackValue: nArgs.
	prevClass _ self fetchPointer: MethodLinkageIndex ofObject: tMeth.
	"Check prevClass for ConstZero in order to detect flushed methods"
	((self isIntegerObject: rcvr) and: [prevClass = ConstZero]) ifTrue: [
		self executeLinkedSend: tMeth to: rcvr nArgs: nArgs.
	] ifFalse: [
		self relinkSend: tMeth to: rcvr nArgs: nArgs type: type.
	]