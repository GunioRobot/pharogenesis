translate: fileName doInlining: inlineFlag locally: localFlag
	"Time millisecondsToRun: [
		FloatArrayPlugin translate: 'SqFloatArray.c' doInlining: true.
		Smalltalk beep]"
	| cg fullName fd |
	fullName _ self baseDirectoryName.
	fd _ FileDirectory on: fullName.
	localFlag ifFalse:[
		(fd directoryExists: self moduleName) 
			ifFalse:[fd createDirectory: self moduleName].
		fd _ fd on: (fd fullNameFor: self moduleName)].
	fullName _ fd fullNameFor: fileName.
	self initialize.
	self headerFile ifNotNil:[
		(CrLfFileStream newFileNamed: (fd fullNameFor: self moduleName,'.h'))
			nextPutAll: self headerFile;
			close].
	cg _ self codeGeneratorClass new initialize.
	localFlag ifTrue:[cg pluginPrefix: self moduleName].
	"Add an extra declaration for module name"
		cg declareModuleName: self moduleNameAndVersion local: localFlag.


	{InterpreterPlugin. B3DEnginePlugin. B3DTransformerPlugin. B3DVertexBufferPlugin. B3DShaderPlugin. B3DClipperPlugin. B3DPickerPlugin. B3DRasterizerPlugin} do: 
		[:theClass | 
		theClass initialize.
		cg addClass: theClass.
		theClass declareCVarsIn: cg].
	cg storeCodeOnFile: fullName doInlining: inlineFlag.
	B3DRasterizerPlugin writeSupportCode: true.
	^cg