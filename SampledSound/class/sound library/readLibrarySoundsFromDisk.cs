readLibrarySoundsFromDisk
	"Scan the current directory for .aif files, read them in, put them in the sound library"
	"SampledSound readLibrarySoundsFromDisk "

	 (FileDirectory default fileNamesMatching: '*.aif') do:
		[:fileName |
			self addLibrarySoundNamed: (fileName copyUpTo: $.)
				fromAIFFfileNamed: fileName
				sampleRate: 11025].
