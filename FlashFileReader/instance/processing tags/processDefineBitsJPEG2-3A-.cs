processDefineBitsJPEG2: data
	| id image decoder |
	id _ data nextWord.
	decoder _ FlashJPEGDecoder new.
	decoder isStreaming: self isStreaming.
	decoder decodeJPEGTables: data.
	data atEnd
		ifFalse: [
			image _ decoder decodeNextImageFrom: data.
			Preferences compressFlashImages ifTrue:[image _ image asFormOfDepth: 8].
			self recordBitmap: id data: image].
	^true