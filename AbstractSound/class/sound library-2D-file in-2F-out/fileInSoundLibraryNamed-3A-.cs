fileInSoundLibraryNamed: fileName
	"File in the sound library with the given file name, and add its contents to the current sound library."

	| s newSounds |
	s _ FileStream oldFileNamed: fileName.
	newSounds _ s fileInObjectAndCode.
	s close.
	newSounds associationsDo:
		[:assoc | self storeFiledInSound: assoc value named: assoc key].
	ScorePlayerMorph allSubInstances do: [:p | p updateInstrumentsFromLibrary].
	Smalltalk garbageCollect.
