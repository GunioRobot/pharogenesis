storeSunAudioOnFileNamed: fileName
	"Store this sound as an uncompressed Sun audio file of the given name."

	| f |
	f _ (FileStream fileNamed: fileName) binary.
	self storeSunAudioSamplesOn: f.
	f close.
