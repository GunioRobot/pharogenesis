writeHeaderExtent: movieExtent frameRate: frameRate frameCount: frameCount soundtrackCount: soundtrackCount on: aBinaryStream
	"Write a header on the given stream for a JPEG movie file with the given specifications. Leave the stream positioned at the start of the first movie frame."

	| offsetCount |
	aBinaryStream position: 0.
	aBinaryStream nextPutAll: ('JPEG Movie') asByteArray.
	aBinaryStream uint16: movieExtent x.
	aBinaryStream uint16: movieExtent y.
	aBinaryStream uint32: (frameRate * 10000) rounded.
	offsetCount _ frameCount + 1.
	aBinaryStream uint32: offsetCount.
	aBinaryStream skip: (offsetCount * 4).  "leave room for frame offsets"
	aBinaryStream uint16: soundtrackCount.
	aBinaryStream skip: (soundtrackCount * 4).  "leave room for sound track offsets"
