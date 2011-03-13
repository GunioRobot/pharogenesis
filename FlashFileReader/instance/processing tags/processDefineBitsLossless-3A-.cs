processDefineBitsLossless: data
	"TODO: Read zlib compressed data."
	| id format width height |
	id := data nextWord.
	format := data nextByte.
	width := data nextWord.
	height := data nextWord.
	self recordBitmap: id data: nil.
	^true