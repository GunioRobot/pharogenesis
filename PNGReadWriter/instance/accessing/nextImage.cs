nextImage

	| length type dataChunk |

	dataChunk _ nil.
	stream reset.
	(stream respondsTo: #binary) ifTrue: [ stream binary] .
	stream skip: 8.
	[stream atEnd] whileFalse: [
		length _ self nextLong.
		type _ self nextLong.
		chunk _ self next: length.
		"crc _" self nextLong. "TODO - validate crc"
		type = IHDR ifTrue: [self processIHDRChunk].
		type = PLTE ifTrue: [self processPLTEChunk].
		type = IDAT ifTrue: [
			"---since the compressed data can span multiple
			chunks, stitch them all together first. later,
			if memory is an issue, we need to figure out how
			to do this on the fly---"
			dataChunk _ dataChunk ifNil: [chunk] ifNotNil:
				[dataChunk,chunk].
		].
	].
	chunk _ dataChunk.
	chunk ifNotNil: [self processIDATChunk].
	^ form
