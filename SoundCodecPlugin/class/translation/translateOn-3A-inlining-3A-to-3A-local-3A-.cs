translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"do the actual translation"
	| fd |
	super translateOn: cg inlining: inlineFlag to: fullName local: localFlag.
	fd _ FileDirectory on: (FileDirectory dirPathFor: fullName).
	(CrLfFileStream newFileNamed: (fd fullNameFor: 'sqGSMCodecPlugin.c'))
		nextPutAll: self sourceFile;
		close.
