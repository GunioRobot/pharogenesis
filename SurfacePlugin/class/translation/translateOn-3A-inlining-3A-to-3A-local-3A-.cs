translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"do the actual translation"
	| theClass fd |
	theClass _ self.
	[theClass == Object] whileFalse:[
		cg addClass: theClass.
		theClass declareCVarsIn: cg.
		theClass _ theClass superclass].
	"cg storeCodeOnFile: fullName doInlining: inlineFlag."
	fd _ FileDirectory on: (FileDirectory dirPathFor: fullName).
	(CrLfFileStream newFileNamed: (fd fullNameFor: self moduleName,'.c'))
		nextPutAll: 
			(self sourceCode 
				copyReplaceAll:'$$SURFACE_PLUGIN_STANDALONE$$'
				with: (localFlag ifTrue:['0'] ifFalse:['1']));
		close.
