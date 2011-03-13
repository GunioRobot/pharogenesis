translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"SoundGenerationPlugin translateLocally"
	| code fd theClass |
	theClass _ self.
	[theClass == Object] whileFalse:[
		cg addClass: theClass.
		theClass declareCVarsIn: cg.
		theClass _ theClass superclass].

	cg addMethodsForPrimitives: AbstractSound translatedPrimitives.
	code _ cg generateCodeStringForPrimitives.
	self storeString: code onFileNamed: fullName.
	fd _ FileDirectory on: (FileDirectory dirPathFor: fullName).
	(CrLfFileStream newFileNamed: (fd fullNameFor: 'sqOldSoundPrims.c'))
		nextPutAll: self oldSourceFile;
		close.