raw16BitDataFromAIFFfileNamed: fileName
	"Read a 16-bit SampledSound from the AIFF file of the given name. This method skips the header without parsing it; it assumes the file contains 16-bit uncompressed mono data as recorded by the shareware program SoundMachine 2.1. The headers of such AIFF files are 54 bytes."

	| raw n data w src |
	raw _ self rawDataFromAIFFfileNamed: fileName.
	n _ raw size // 2.
	data _ SoundBuffer newMonoSampleCount: n.
	src _ 1.
	1 to: n do: [:i |
		w _ raw at: src.
		w _ (w bitShift: 8) + (raw at: src + 1).
		w > 32767 ifTrue: [w _ 65536 - w].
		data at: i put: w.
		src _ src + 2].
	^ data
