primitiveObsoleteIndexedPrimitive
	"Primitive. Invoke an obsolete indexed primitive."
	| pluginName functionName functionAddress |
	self var: #pluginName declareC: 'char *pluginName'.
	self var: #functionName declareC: 'char *functionName'.
	"see if the prim has been called before and already has a function pointer set"
	functionAddress _ self cCoerce: ((obsoleteIndexedPrimitiveTable at: primitiveIndex) at: 2) to: 'int'.
	functionAddress = nil
		ifFalse: [^ self cCode: '((int (*) (void))functionAddress)()' inSmalltalk: [self callExternalPrimitive: functionAddress]].

	"try loading the plugin that this old number maps to"
	pluginName _ (obsoleteIndexedPrimitiveTable at: primitiveIndex) at: 0.
	functionName _ (obsoleteIndexedPrimitiveTable at: primitiveIndex) at: 1.
	(pluginName = nil and: [functionName = nil]) ifTrue: [^ self primitiveFail].
	functionAddress _ self ioLoadFunction: functionName From: pluginName.
	functionAddress = 0
		ifFalse: ["Cache for future use"
			(obsoleteIndexedPrimitiveTable at: primitiveIndex) at: 2 put: (self cCoerce: functionAddress to: 'char*').
			^ self cCode: '((int (*) (void))functionAddress)()' inSmalltalk: [self callExternalPrimitive: functionAddress]].
	^ self primitiveFail