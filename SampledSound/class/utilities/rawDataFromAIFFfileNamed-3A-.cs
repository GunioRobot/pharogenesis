rawDataFromAIFFfileNamed: fileName
	"Read a SampledSound from the AIFF file of the given name. This method skips the header without parsing it; it assumes the file contains 8-bit uncompressed mono data as recorded by the shareware program SoundMachine 2.1. The headers of such AIFF files are 54 bytes."
	"(SampledSound fromAIFFfileNamed: '1.aif') play"

	| data f sz |
	f _ (FileStream oldFileNamed: fileName) binary.
	sz _ f size.
	f skip: 54.  "skip AIFF header"
	data _ (f next: sz - 54).
	f close.
	^ data
