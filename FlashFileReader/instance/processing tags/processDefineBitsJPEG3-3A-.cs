processDefineBitsJPEG3: data
	"TODO: Read zlib compressed alpha."
	| id image decoder alphaOffset dataOffset |
	id _ data nextWord.
	self flag: #wrongSpec.
	alphaOffset _ data nextWord.
	dataOffset _ data nextWord.
	decoder _ FlashJPEGDecoder new.
	decoder isStreaming: self isStreaming.
	decoder decodeJPEGTables: data.
	image _ decoder decodeNextImageFrom: data.
	Preferences compressFlashImages ifTrue:[image _ image asFormOfDepth: 8].
	"Note: We must read the zlib compressed alpha values here."
	self recordBitmap: id data: image.
	^true