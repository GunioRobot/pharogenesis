translate: fileName doInlining: inlineFlag locally: localFlag
	"Time millisecondsToRun: [
		SurfacePlugin translate.
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
	localFlag ifTrue:[cg pluginPrefix: self moduleName].
	"Add an extra declaration for module name"
	cg var: #moduleName declareC:'const char *moduleName = "', self moduleName,'"'.

	theClass _ self.
	[theClass == Object] whileFalse:[
		cg addClass: theClass.
		theClass declareCVarsIn: cg.
		theClass _ theClass superclass].
	"cg storeCodeOnFile: fullName doInlining: inlineFlag."
	(CrLfFileStream newFileNamed: (fd fullNameFor: self moduleName,'.c'))
		nextPutAll: 
			(self sourceCode 
				copyReplaceAll:'$$SURFACE_PLUGIN_STANDALONE$$'
				with: (localFlag ifTrue:['0'] ifFalse:['1']));
		close.
	^cg