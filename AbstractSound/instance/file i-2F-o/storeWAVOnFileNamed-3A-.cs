storeWAVOnFileNamed: fileName
	"Store this sound as a 16-bit Windows WAV file of the given name."

	| f |
	f _ (FileStream fileNamed: fileName) binary.
	self storeWAVSamplesOn: f.
	f close.
