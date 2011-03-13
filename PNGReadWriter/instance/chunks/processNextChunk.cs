processNextChunk

	| length asciiType |

	length _ self nextLong.
	asciiType _ (self next: 4) asString.
	chunk _ self next: length.
	"crc _" self nextLong. "TODO - validate crc"
	asciiType = 'IEND' ifTrue: [^self	"*should* be the last chunk"].
	asciiType = 'sBIT' ifTrue: [^self	"could indicate unusual sample depth in original"].
	asciiType = 'gAMA' ifTrue: [^self 	"indicates gamma correction value"].
	asciiType = 'bKGD' ifTrue: [^self processBackgroundChunk].
	asciiType = 'pHYs' ifTrue: [^self processPhysicalPixelChunk].
	asciiType = 'tRNS' ifTrue: [^self processTransparencyChunk].

	asciiType = 'IHDR' ifTrue: [^self processIHDRChunk].
	asciiType = 'PLTE' ifTrue: [^self processPLTEChunk].
	asciiType = 'IDAT' ifTrue: [
		"---since the compressed data can span multiple
		chunks, stitch them all together first. later,
		if memory is an issue, we need to figure out how
		to do this on the fly---"
		globalDataChunk _ globalDataChunk ifNil: [chunk] ifNotNil:
			[globalDataChunk,chunk].
		^self
	].
	unknownChunks add: asciiType.
