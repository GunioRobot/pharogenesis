buildCodeGeneratorUpTo: aPluginClass
	"Build a CCodeGenerator for the plugin"
	 | cg theClass |
	cg _ self codeGeneratorClass new initialize.
	cg pluginName: self moduleName.
	"Add an extra declaration for module name"
	cg declareModuleName: self moduleNameAndVersion.

	theClass _ aPluginClass.
	[theClass == Object] whileFalse:[
		cg addClass: theClass.
		theClass _ theClass superclass].
	^cg