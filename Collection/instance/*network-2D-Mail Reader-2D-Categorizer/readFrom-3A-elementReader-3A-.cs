readFrom: aStream elementReader: aBlock
	| numberOfElements |
	numberOfElements _ aStream binary; nextWord.
	numberOfElements timesRepeat: [self add: (aBlock value: aStream)].