processDefineBits: data
	| id image |
	id _ data nextWord.
	image _ jpegDecoder decodeNextImageFrom: data.
	Preferences compressFlashImages ifTrue:[image _ image asFormOfDepth: 8].
	"image display."
	self recordBitmap: id data: image.
	^true