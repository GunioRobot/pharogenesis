storeAIFFOnFileNamed: fileName
	"Store this sound as a AIFF file of the given name."

	| f |
	f _ (FileStream fileNamed: fileName) binary.
	self storeAIFFSamplesOn: f.
	f close.
