processDefineBitsJPEG2: data
	| id image decoder sPos |
	id := data nextWord.
	decoder := FlashJPEGDecoder new.
	decoder isStreaming: self isStreaming.
	sPos := data stream position.
	decoder decodeJPEGTables: data.
	data stream position: sPos.
	data atEnd
		ifFalse: [
			image := decoder decodeNextImageFrom: data.
			Preferences compressFlashImages ifTrue:[image := image asFormOfDepth: 8].
			self recordBitmap: id data: image].
	^true