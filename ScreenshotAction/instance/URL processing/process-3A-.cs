process: request
	FileDirectory default deleteFileNamed: 'screenshot.GIF'.
	GIFReadWriter putForm: Display onFileNamed: 'screenshot.GIF'.
	request reply: (PWS success), (PWS content: 'image/gif'), PWS crlf.
	request reply: (FileStream fileNamed: 'screenshot.GIF') contentsOfEntireFile.
