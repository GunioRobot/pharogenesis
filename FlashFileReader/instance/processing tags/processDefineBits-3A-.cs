processDefineBits: data
	| id image |
	id := data nextWord.
	image := jpegDecoder decodeNextImageFrom: data.
	Preferences compressFlashImages ifTrue:[image := image asFormOfDepth: 8].
	"image display."
	self recordBitmap: id data: image.
	^true