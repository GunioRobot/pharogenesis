cFunctionNameFor: aSelector
	"Create a C function name from the given selector by omitting colons
	and prefixing with the plugin name if the method is exported."
	| meth |
	pluginPrefix == nil ifTrue:[^aSelector copyWithout: $:].
	meth _ methods at: aSelector ifAbsent:[nil].
	(meth notNil and:[meth export])
		ifTrue:[^pluginPrefix,'_', (aSelector copyWithout: $:)]
		ifFalse:[^aSelector copyWithout: $:].