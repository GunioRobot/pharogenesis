on: aCollection from: firstIndex to: lastIndex
	bitBuf _ bitPos _ 0.
	"The decompression buffer has a size of at 64k,
	since we may have distances up to 32k back and
	repetitions of at most 32k length forward"
	collection _ aCollection species new: 1 << 16.
	readLimit _ 0. "Not yet initialized"
	position _ 0.
	source _ aCollection.
	sourceLimit _ lastIndex.
	sourcePos _ firstIndex-1.
	state _ StateNewBlock.