needsToRegenerateInterpreterFile
"check the timestamp for the relevant classes and then the timestamp for the interp.c file if it already exists. Return true if the file needs regenerating, false if not"

	| tStamp fstat |
	tStamp _ { self interpreterClass. ObjectMemory} inject: 0 into: [:tS :cl|
		tS _ tS max: cl timeStamp].

	"don't translate if the file is newer than my timeStamp"
	fstat _ self coreVMDirectory entryAt: self interpreterFilename ifAbsent:[nil].
	fstat ifNotNil:[tStamp < fstat modificationTime ifTrue:[^false]].
	^true