writeEPSPreviewImageFor: aMorph
	| form stream string lines newExtent |
	newExtent _ (aMorph width roundUpTo: 8) @ aMorph height.
	form _ aMorph imageForm: 1 forRectangle: (aMorph bounds origin extent: newExtent).
	stream _ RWBinaryOrTextStream on: (String new: (form bits byteSize * 2.04) asInteger).
	form storePostscriptHexOn: stream.
	string _ stream contents.
	lines _ string occurrencesOf: Character cr.

	"%%BeginPreview: 80 24 1 24"
	"width height depth "
	target print: '%%BeginPreview: '; write:  newExtent; space; write: form depth; space; write: lines; cr.

	stream position: 0.
	[ stream atEnd ] whileFalse: [
		target nextPut: $%; nextPutAll: (stream upTo: Character cr); cr.
		lines _ lines - 1.
	].

	target print: '%%EndPreview'; cr.

