translate: fileName doInlining: inlineFlag locally: localFlag debug: debugFlag
	"Time millisecondsToRun: [
		FloatArrayPlugin translate: 'SqFloatArray.c' doInlining: true.
		Smalltalk beep]"
	| cg theClass fullName fd |
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
	cg generateDebugCode: debugFlag.
	localFlag ifTrue:[cg pluginPrefix: self moduleName].
	"Add an extra declaration for module name"
	cg declareModuleName: self moduleNameAndVersion local: localFlag.

	theClass _ self.
	[theClass == Object] whileFalse:[
		cg addClass: theClass.
		theClass declareCVarsIn: cg.
		theClass _ theClass superclass].
	cg storeCodeOnFile: fullName doInlining: inlineFlag.
	^cg