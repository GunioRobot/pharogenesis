retrieveMIMEDocument: uri
	| file |
	file  := [self contentStreamForURI: uri] 
			on: FileDoesNotExistException do:[:ex| ex return: nil].
	file ifNotNil: [^MIMEDocument contentStream: file 
					mimeType: (MIMEType forURIReturnSingleMimeTypeOrDefault: uri)].
	^nil