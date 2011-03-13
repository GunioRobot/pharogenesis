processJPEGTables: data
	jpegDecoder := FlashJPEGDecoder new.
	jpegDecoder isStreaming: self isStreaming.
	jpegDecoder decodeJPEGTables: data.
	^true