relinkSend: tMeth to: rcvr nArgs: nArgs type: type

	| selector |
	self inline: true.

	selector _ self fetchPointer: MethodSelectorIndex ofObject: tMeth.
	self externalizeIPandSP.
	self linkAndSendSelector: selector to: rcvr nArgs: nArgs type: type.
	self internalizeIPandSP.