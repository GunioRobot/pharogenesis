processDefineBitsLossless2: data
	"TODO: Read zlib compressed data."
	| id format width height |
	id _ data nextWord.
	format _ data nextByte.
	width _ data nextWord.
	height _ data nextWord.
	self recordBitmap: id data: nil.
	^true