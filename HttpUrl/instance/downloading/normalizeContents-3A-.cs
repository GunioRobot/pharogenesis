normalizeContents: webDocument
	webDocument contentType = MIMEDocument defaultContentType ifTrue: [
		^MIMEDocument contentType: (MIMEDocument guessTypeFromName: self path last) 
			content: webDocument content url: webDocument url ].
	(webDocument isKindOf: String) ifTrue: [
		^MIMEDocument
			contentType: 'text/plain'
			content: 'error occured retrieving ', self toText, ': ', webDocument].

	^webDocument