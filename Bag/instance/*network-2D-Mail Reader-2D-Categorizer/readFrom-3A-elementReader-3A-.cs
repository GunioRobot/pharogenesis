readFrom: aStream elementReader: aBlock
	| numberOfDistinctElements count x |
	numberOfDistinctElements _ aStream binary; nextInt32.
	numberOfDistinctElements timesRepeat: [
		count _ aStream binary; nextInt32.
		x _ aBlock value: aStream.
		self add: x withOccurrences: count.
	].