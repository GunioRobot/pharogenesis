ioLoadExternalFunction: functionName OfLength: functionLength FromModule: moduleName OfLength: moduleLength
	"Load and return the requested function from a module"
	| pluginString functionString |
	pluginString _ String new: moduleLength.
	1 to: moduleLength do:[:i| pluginString byteAt: i put: (self byteAt: moduleName+i-1)].
	functionString _ String new: functionLength.
	1 to: functionLength do:[:i| functionString byteAt: i put: (self byteAt: functionName+i-1)].
	functionString _ functionString asSymbol.
	^self ioLoadFunction: functionString From: pluginString