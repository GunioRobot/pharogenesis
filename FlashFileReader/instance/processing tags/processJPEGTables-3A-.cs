processJPEGTables: data
	jpegDecoder _ FlashJPEGDecoder new.
	jpegDecoder isStreaming: self isStreaming.
	jpegDecoder decodeJPEGTables: data.
	^true