fromFile: aPositionableStream onFileNumber: anInteger toFile: aFileStream 
	"Store the next chunk from aPositionableStream as the receiver's string."

	| position |
	sourceFileNumber _ anInteger.
	filePositionHi _ (position _ aFileStream position) bitShift: -8.
	filePositionLo _ position bitAnd: 255.
	aPositionableStream copyChunkTo: aFileStream