primitiveUnloadModule
	"Primitive. Unload the module with the given name."
	"Reloading of the module will happen *later* automatically, when a 
	function from it is called. This is ensured by invalidating current sessionID."
	| moduleName |
	self methodArgumentCount = 1 ifFalse:[^self success: false].
	moduleName _ self stackValue: 0.
	(self isIntegerObject: moduleName) ifTrue:[^self success: false].
	(self isBytes: moduleName) ifFalse:[^self success: false].
	(self ioUnloadModule: (self cCoerce: (self firstIndexableField: moduleName) to: 'int')
		OfLength: (self byteSizeOf: moduleName)) ifFalse:[^self success: false].
	self flushExternalPrimitives.
	self pop: 1 "pop moduleName; return receiver"